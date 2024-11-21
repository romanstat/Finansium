import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
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

  getUser(): User {
    
    localStorage.setItem(
      Constants.User,
      JSON.stringify({
        id: '123',
        country: 'РБ',
        name: 'Роман',
        surname: 'Статкевич',
        patronymic: 'Викторович',
        email: 'romanstat@mail.ru',
        username: 'b00045873',
        isBlocked: false,
        roles: [
          {
            id: '123',
            name: 'user',
          },
          {
            id: '1234',
            name: 'admin',
          },
        ],
      })
    );
    
    var user = localStorage.getItem(Constants.User);

    if (!user) {
      this.httpClient
        .get<User>(`${Constants.ApiUrl}/users`)
        .pipe(
          map((user) =>
            localStorage.setItem(Constants.User, JSON.stringify(user))
          )
        );
    }

    return JSON.parse(localStorage.getItem(Constants.User)!);
  }

  logout(): void {
    localStorage.removeItem(Constants.AccessToken);
    localStorage.removeItem(Constants.User);
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem(Constants.AccessToken);

    return !!token;
  }

  refreshToken() {
    return this.httpClient
      .post<{ access_token: string }>(
        `${Constants.ApiUrl}/users/refresh-token`,
        {}
      )
      .pipe(
        map((response) => {
          localStorage.setItem(Constants.AccessToken, response.access_token);
        })
      );
  }
}
