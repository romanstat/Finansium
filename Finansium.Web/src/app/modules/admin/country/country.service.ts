import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { HttpClient } from '@angular/common/http';
import { Country } from '../../../core/model/common.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<Country[]>(`${Constants.ApiUrl}/countries`);
  }
}
