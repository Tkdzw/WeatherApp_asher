import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {

  private tokenKey = 'weather_token';
  user = signal<any>(null);

  constructor(private http: HttpClient) {}

  register(data: any) {
    return this.http.post(`${environment.apiUrl}/auth/register`, data)
      .pipe(
        tap((res: any) => this.setSession(res))
      );
  }

  login(data: any) {
    return this.http.post(`${environment.apiUrl}/auth/login`, data)
      .pipe(
        tap((res: any) => this.setSession(res))
      );
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    this.user.set(null);
  }

  private setSession(res: any) {
    localStorage.setItem(this.tokenKey, res.token);
    this.user.set(res);
  }

  get token() {
    return localStorage.getItem(this.tokenKey);
  }

  get isAuthenticated() {
    return !!this.token;
  }
}
