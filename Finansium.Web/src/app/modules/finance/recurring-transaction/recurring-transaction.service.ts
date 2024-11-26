import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { RecurringTransaction } from './recurring-transaction.model';

@Injectable({
  providedIn: 'root',
})
export class RecurringTransactionService {
  constructor(private readonly httpClient: HttpClient) {}

  search() {
    return this.httpClient.post<RecurringTransaction[]>(
      `${Constants.ApiUrl}/recurring-transactions/search`,
      {}
    );
  }

  create(recurringTransaction: RecurringTransaction) {
    return this.httpClient.post(
      `${Constants.ApiUrl}/recurring-transactions`,
      recurringTransaction
    );
  }

  delete(id: string) {
    return this.httpClient.delete(
      `${Constants.ApiUrl}/recurring-transactions/${id}`
    );
  }
}
