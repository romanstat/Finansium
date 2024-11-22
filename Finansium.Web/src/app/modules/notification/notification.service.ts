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
      `${Constants.ApiUrl}/users/notifications`
    );
  }

  getAllNotToday() {
    return this.httpClient.get<Notify[]>(
      `${Constants.ApiUrl}/users/notifications`
    );
  }

  updateViewed(id: string) {
    return this.httpClient.put(
      `${Constants.ApiUrl}/users/notifications/${id}/change-view`,
      []
    );
  }

  updateUnreadCount() {
    this.httpClient
      .get<number>(`${Constants.ApiUrl}/users/notifications/unread-count`)
      .subscribe({
        next: (result) => {
          this.unreadCountSubject.next(result);
        },
      });
  }
}
