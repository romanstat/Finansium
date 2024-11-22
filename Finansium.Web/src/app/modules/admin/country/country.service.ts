import { Injectable } from '@angular/core';
import { Constants } from '../../../core/constant';
import { HttpClient } from '@angular/common/http';
import { Country } from '../../../core/common.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll(searchTerm: string = '') {
    return this.httpClient.post<Country[]>(
      `${Constants.ApiUrl}/countries/search`,
      { searchTerm }
    );
  }
}
