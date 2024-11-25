import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../constant';
import { Currency } from '../common.model';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  constructor(private readonly httpClient: HttpClient) {}

  search() {
    return this.httpClient.post<Currency[]>(
      `${Constants.ApiUrl}/currencies/search`,
      {}
    );
  }

  getRate(fromCurrency: string, toCurrency: string) {
    return this.httpClient.get<number>(
      `${Constants.ApiUrl}/currencies/${fromCurrency}/${toCurrency}`
    );
  }
}
