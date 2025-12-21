export interface AuthTokens {
  accessToken: string;
  refreshToken: string;
  expiresAtUtc: string; // ISO string in UTC
}

export const ACCESS_TOKEN_KEY = 'auth_access_token';
export const REFRESH_TOKEN_KEY = 'auth_refresh_token';
export const EXPIRES_AT_KEY = 'auth_expires_utc';

export function setTokens(tokens: AuthTokens): void {
  localStorage.setItem(ACCESS_TOKEN_KEY, tokens.accessToken);
  localStorage.setItem(REFRESH_TOKEN_KEY, tokens.refreshToken);
  localStorage.setItem(EXPIRES_AT_KEY, tokens.expiresAtUtc);
}

export function getAccessToken(): string | null {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

export function getRefreshToken(): string | null {
  return localStorage.getItem(REFRESH_TOKEN_KEY);
}

export function getExpiresAtUtc(): string | null {
  return localStorage.getItem(EXPIRES_AT_KEY);
}

// Small safety skew to refresh slightly before exact expiry
export function isTokenExpired(skewMs = 5000): boolean {
  const expires = getExpiresAtUtc();
  if (!expires) return true;
  const expMs = Date.parse(expires);
  if (Number.isNaN(expMs)) return true;
  return Date.now() + skewMs >= expMs;
}

export function clearTokens(): void {
  localStorage.removeItem(ACCESS_TOKEN_KEY);
  localStorage.removeItem(REFRESH_TOKEN_KEY);
  localStorage.removeItem(EXPIRES_AT_KEY);
}
