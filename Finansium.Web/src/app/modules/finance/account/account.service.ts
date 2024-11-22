import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { Account } from './account.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<Account[]>(`${Constants.ApiUrl}/accounts/list`);
  }
}
