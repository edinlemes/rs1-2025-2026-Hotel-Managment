import { Injectable } from '@angular/core';
import { axiosInstance } from '../http/axios.config';
import { setTokens, clearTokens, getAccessToken, isTokenExpired } from './token.storage';

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  accessToken: string;
  refreshToken: string;
  expiresAtUtc: string;
}

export interface RegisterRequest {
  firstName: string;
  lastName: string;
  address: string;
  city: string;
  state: string;
  zipCode: string;
  country: string;
  phoneNumber: string;
  gender: string;
  email: string;
  password: string;
}

export interface RegisterResponse {
  id: number;
  email: string;
  firstName: string;
  lastName: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  async login(payload: LoginRequest): Promise<LoginResponse> {
    const { data } = await axiosInstance.post<LoginResponse>('/auth/login', payload);
    setTokens({ accessToken: data.accessToken, refreshToken: data.refreshToken, expiresAtUtc: data.expiresAtUtc });
    return data;
  }

  async register(payload: RegisterRequest): Promise<RegisterResponse> {
    const { data } = await axiosInstance.post<RegisterResponse>('/auth/register', payload);
    return data;
  }

  async refreshToken(): Promise<LoginResponse> {
    const refreshToken = localStorage.getItem('auth_refresh_token');
    if (!refreshToken) throw new Error('No refresh token');
    const { data } = await axiosInstance.post<LoginResponse>('/auth/refresh', { refreshToken });
    setTokens({ accessToken: data.accessToken, refreshToken: data.refreshToken, expiresAtUtc: data.expiresAtUtc });
    return data;
  }

  logout(): void {
    clearTokens();
  }

  isAuthenticated(): boolean {
    const token = getAccessToken();
    return !!token && !isTokenExpired();
  }

  getAccessToken(): string | null {
    return getAccessToken();
  }
}
