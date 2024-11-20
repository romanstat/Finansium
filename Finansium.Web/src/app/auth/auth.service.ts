import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Constants } from '../core/constant';
import { Router } from '@angular/router';
import { User } from '../core/model/common.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  httpClient = inject(HttpClient);
  router = inject(Router);

  login(credentials: any) {
    return this.httpClient
      .post<{ access_token: string }>(
        `${Constants.ApiUrl}/users/login`,
        credentials
      )
      .pipe(
        map((response) =>
          localStorage.setItem(Constants.AccessToken, response.access_token)
        )
      );
  }

  register(payload: any) {
    return this.httpClient.post(`${Constants.ApiUrl}/users/register`, payload);
  }

  getUserInfo(): User | null {
    return null;
  }

  logout(): void {
    localStorage.removeItem(Constants.AccessToken);
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem(Constants.AccessToken);

    return !!token;
  }
}
