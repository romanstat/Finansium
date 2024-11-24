import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../../../core/common.model';
import { Constants } from '../../../core/constant';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll(searchTerm: string = '') {
    return this.httpClient.post<User[]>(`${Constants.ApiUrl}/users/search`, {
      searchTerm,
    });
  }

  update(user: User) {
    return this.httpClient.put(`${Constants.ApiUrl}/users/update`, user);
  }
}
