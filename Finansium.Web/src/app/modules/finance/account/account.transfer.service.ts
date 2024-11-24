import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { HttpClient } from '@angular/common/http';
import { AccountTransfer } from './account.model';

@Injectable({
  providedIn: 'root'
})
export class AccountTransferService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<AccountTransfer[]>(`${Constants.ApiUrl}/account-tansfers/list`);
  }
}
