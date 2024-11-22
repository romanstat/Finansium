import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../core/constant';
import { News } from './news.model';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<News[]>(`${Constants.ApiUrl}/news/search/relevant`);
  }

  create(payload: any) {
    return this.httpClient.post<string>(`${Constants.ApiUrl}/news`, payload);
  }

  update(payload: any) {
    return this.httpClient.put<string>(`${Constants.ApiUrl}/news`, payload);
  }

  outdate(id: string) {
    return this.httpClient.post(`${Constants.ApiUrl}/news/${id}/outdate`, []);
  }
}
