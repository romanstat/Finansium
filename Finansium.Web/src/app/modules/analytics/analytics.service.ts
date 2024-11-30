import { Injectable } from '@angular/core';
import { Analytic } from './analytics.model';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../core/constant';

@Injectable({
  providedIn: 'root',
})
export class AnalyticsService {
  constructor(private readonly httpClient: HttpClient) {}

  get(startDate: string, endDate: string) {
    return this.httpClient.post<Analytic>(
      `${Constants.ApiUrl}/analystics`,
      {
        startDate: startDate,
        endDate: endDate,
      }
    );
  }
}
