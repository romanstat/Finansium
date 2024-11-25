import { Injectable } from '@angular/core';
import { SavingsGoal } from './savings-goal.model';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../core/constant';

@Injectable({
  providedIn: 'root',
})
export class SavingsGoalService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<SavingsGoal[]>(
      `${Constants.ApiUrl}/savings-goals/list`
    );
  }

  create(savingsGoal: SavingsGoal) {
    return this.httpClient.post(
      `${Constants.ApiUrl}/savings-goals`,
      savingsGoal
    );
  }

  update(savingsGoal: SavingsGoal) {
    return this.httpClient.put(
      `${Constants.ApiUrl}/savings-goals`,
      savingsGoal
    );
  }

  delete(id: string) {
    return this.httpClient.delete(`${Constants.ApiUrl}/savings-goals/${id}`);
  }
}
