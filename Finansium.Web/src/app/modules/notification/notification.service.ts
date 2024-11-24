import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../../core/constant';
import { Notify } from './notification.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private unreadCountSubject = new BehaviorSubject<number | 0>(0);
  unreadCount$ = this.unreadCountSubject.asObservable();

  constructor(private readonly httpClient: HttpClient) {}

  getAllToday() {
    return this.httpClient.get<Notify[]>(
      `${Constants.ApiUrl}/notifications/today`
    );
  }

  getAllNotToday() {
    return this.httpClient.get<Notify[]>(
      `${Constants.ApiUrl}/notifications/older`
    );
  }

  viewedAll() {
    return this.httpClient.put(
      `${Constants.ApiUrl}/notifications/viewed-all`,
      []
    );
  }

  updateViewed(id: string) {
    return this.httpClient.put(
      `${Constants.ApiUrl}/notifications/${id}/view-status`,
      []
    );
  }

  updateUnreadCount() {
    this.httpClient
      .get<number>(`${Constants.ApiUrl}/notifications/unread-count`)
      .subscribe({
        next: (result) => {
          this.unreadCountSubject.next(result);
        },
      });
  }
}
