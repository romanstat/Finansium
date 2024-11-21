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
    return this.httpClient.get<News[]>(`${Constants.ApiUrl}/news`);
  }

  create(payload: any) {
    return this.httpClient.post<News[]>(`${Constants.ApiUrl}/news`, payload);
  }

  update(payload: any) {
    return this.httpClient.put<News[]>(`${Constants.ApiUrl}/news`, payload);
  }

  delete(id: string) {
    return this.httpClient.delete(`${Constants.ApiUrl}/news/${id}`);
  }
}
