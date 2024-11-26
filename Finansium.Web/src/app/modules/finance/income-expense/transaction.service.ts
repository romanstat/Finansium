import { Injectable } from '@angular/core';
import { Transaction } from './transaction.model';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../core/constant';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  constructor(private readonly httpClient: HttpClient) {}

  search() {
    return this.httpClient.post<Transaction[]>(
      `${Constants.ApiUrl}/transactions/search`, {}
    );
  }

  createIncome(transaction: Transaction) {
    return this.httpClient.post(
      `${Constants.ApiUrl}/transactions/income`,
      transaction
    );
  }

  createExpense(transaction: Transaction) {
    return this.httpClient.post(
      `${Constants.ApiUrl}/transactions/expense`,
      transaction
    );
  }

  update(transaction: Transaction) {
    return this.httpClient.put(`${Constants.ApiUrl}/transactions`, transaction);
  }

  delete(id: string) {
    return this.httpClient.delete(`${Constants.ApiUrl}/transactions/${id}`);
  }
}
