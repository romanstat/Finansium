import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { CategoryBudget } from './budget.model';

@Injectable({
  providedIn: 'root',
})
export class BudgetService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<CategoryBudget[]>(
      `${Constants.ApiUrl}/categories/budgets`
    );
  }
}
