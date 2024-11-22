import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { TransactionType } from '../../../core/common.model';
import { HttpClient } from '@angular/common/http';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private readonly httpClient: HttpClient) {}

  search(type: TransactionType) {
    return this.httpClient.post<Category[]>(
      `${Constants.ApiUrl}/categories/search`,
      { type }
    );
  }

  createExpense(category: Category) {
    return this.httpClient.post<string>(
      `${Constants.ApiUrl}/categories/expense`,
      category
    );
  }

  createIncome(category: Category) {
    return this.httpClient.post<string>(
      `${Constants.ApiUrl}/categories/income`,
      category
    );
  }

  update(category: Category) {
    return this.httpClient.put(`${Constants.ApiUrl}/categories`, category);
  }

  delete(id: string) {
    return this.httpClient.delete(`${Constants.ApiUrl}/categories/${id}`);
  }
}
