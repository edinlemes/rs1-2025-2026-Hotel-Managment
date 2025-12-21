import axios, { AxiosError, AxiosInstance, AxiosRequestConfig } from 'axios';
import {
  getAccessToken,
  getRefreshToken,
  isTokenExpired,
  setTokens,
  clearTokens,
} from '../auth/token.storage';

const baseURL = 'https://localhost:7260/api';

const api: AxiosInstance = axios.create({
  baseURL,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
  },
});

let isRefreshing = false;
let refreshPromise: Promise<string> | null = null; // resolves to new access token
const queuedRequests: Array<(token: string | null) => void> = [];

function queueRequest(callback: (token: string | null) => void) {
  queuedRequests.push(callback);
}

function resolveQueue(token: string | null) {
  while (queuedRequests.length) {
    const cb = queuedRequests.shift();
    try {
      cb?.(token);
    } catch {}
  }
}

async function performRefresh(): Promise<string> {
  const refreshToken = getRefreshToken();
  if (!refreshToken) {
    clearTokens();
    throw new Error('No refresh token');
  }
  // Use a plain axios instance to avoid interceptor loops
  const plain = axios.create({ baseURL, headers: { 'Content-Type': 'application/json' } });
  const { data } = await plain.post<{
    accessToken: string;
    refreshToken: string;
    expiresAtUtc: string;
  }>('/auth/refresh', { refreshToken });
  setTokens({ accessToken: data.accessToken, refreshToken: data.refreshToken, expiresAtUtc: data.expiresAtUtc });
  return data.accessToken;
}

api.interceptors.request.use(async (config) => {
  const url = String(config.url ?? '');
  const isAuthEndpoint = url.includes('/auth/login') || url.includes('/auth/refresh');

  const token = getAccessToken();
  // Attach current token if present
  if (token) {
    config.headers = config.headers ?? {};
    (config.headers as Record<string, string>)["Authorization"] = `Bearer ${token}`;
  }

  // Only refresh if this is NOT an auth endpoint and we already have a token
  if (!isAuthEndpoint && token && isTokenExpired()) {
    if (!isRefreshing) {
      isRefreshing = true;
      refreshPromise = performRefresh()
        .then((newToken) => {
          resolveQueue(newToken);
          return newToken;
        })
        .catch((err) => {
          clearTokens();
          resolveQueue(null);
          throw err;
        })
        .finally(() => {
          isRefreshing = false;
        });
    }

    // Wait for the refresh to complete and update the header
    const newToken = await refreshPromise!;
    config.headers = config.headers ?? {};
    (config.headers as Record<string, string>)["Authorization"] = newToken ? `Bearer ${newToken}` : '';
  }

  return config;
});

api.interceptors.response.use(
  (response) => response,
  async (error: AxiosError) => {
    const originalRequest = error.config as AxiosRequestConfig & { _retry?: boolean };
    const url = String(originalRequest.url ?? '');
    const isAuthEndpoint = url.includes('/auth/login') || url.includes('/auth/refresh');

    if (error.response?.status === 401 && !originalRequest._retry && !isAuthEndpoint) {
      originalRequest._retry = true;

      try {
        // If not already refreshing, start it; otherwise wait
        if (!isRefreshing) {
          isRefreshing = true;
          refreshPromise = performRefresh()
            .then((newToken) => {
              resolveQueue(newToken);
              return newToken;
            })
            .catch((err) => {
              clearTokens();
              resolveQueue(null);
              throw err;
            })
            .finally(() => {
              isRefreshing = false;
            });
        }

        const newToken = await refreshPromise!;
        originalRequest.headers = originalRequest.headers ?? {};
        (originalRequest.headers as Record<string, string>)["Authorization"] = newToken ? `Bearer ${newToken}` : '';
        return api.request(originalRequest);
      } catch (refreshErr) {
        clearTokens();
        return Promise.reject(refreshErr);
      }
    }
    return Promise.reject(error);
  }
);

export { api as axiosInstance };
