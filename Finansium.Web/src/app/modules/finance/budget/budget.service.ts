import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { BudgetType, CategoryBudget } from './budget.model';

@Injectable({
  providedIn: 'root',
})
export class BudgetService {
  constructor(private readonly httpClient: HttpClient) {}

  search(type: string) {
    return this.httpClient.post<CategoryBudget[]>(
      `${Constants.ApiUrl}/categories/expense/budgets/search`,
      { type }
    );
  }

  save(budget: CategoryBudget) {
    return this.httpClient.put(
      `${Constants.ApiUrl}/categories/expense/budgets`,
      budget
    );
  }
}
