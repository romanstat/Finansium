import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Constants } from '../core/constant';
import { Router } from '@angular/router';
import { User } from '../core/common.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  httpClient = inject(HttpClient);
  router = inject(Router);

  private userSubject = new BehaviorSubject<User | null>(null);
  user$ = this.userSubject.asObservable();

  private isLoggedInSubject = new BehaviorSubject<boolean>(this.isLoggedIn());

  login(credentials: any) {
    return this.httpClient
      .post<{ accessToken: string }>(
        `${Constants.ApiUrl}/users/login`,
        credentials
      )
      .pipe(
        map((response) =>
          localStorage.setItem(Constants.AccessToken, response.accessToken)
        )
      );
  }

  register(payload: any) {
    return this.httpClient.post(`${Constants.ApiUrl}/users/register`, payload);
  }

  setUser() {
    this.httpClient.get<User>(`${Constants.ApiUrl}/users`).subscribe({
      next: (result) => {
        this.isLoggedInSubject.next(true);
        this.userSubject.next(result);
      },
    });
  }

  logout(): void {
    this.userSubject.next(null);
    this.isLoggedInSubject.next(false);
    localStorage.removeItem(Constants.AccessToken);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem(Constants.AccessToken);
  }

  get isLoggedIn$() {
    return this.isLoggedInSubject.asObservable();
  }

  refreshToken() {
    return this.httpClient
      .post<{ accessToken: string }>(
        `${Constants.ApiUrl}/users/refresh-token`,
        {}
      )
      .pipe(
        map((response) => {
          localStorage.setItem(Constants.AccessToken, response.accessToken);
        })
      );
  }
}
