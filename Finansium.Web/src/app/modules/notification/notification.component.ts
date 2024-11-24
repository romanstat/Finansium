import { Component, inject, OnInit } from '@angular/core';
import { NotificationService } from './notification.service';
import { CommonModule } from '@angular/common';
import { Notify } from './notification.model';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.scss',
})
export class NotificationComponent implements OnInit {
  notificationService = inject(NotificationService);

  todayNotifications: Notify[] = [];
  otherNotifications: Notify[] = [];

  toggleViewed(notification: Notify): void {
    notification.isViewed = !notification.isViewed;
    this.notificationService.updateViewed(notification.id).subscribe({
      next: () => {
        this.loadNotifications();
      },
    });
  }

  viewedAll(): void {
    this.notificationService.viewedAll().subscribe(() =>{
      this.loadNotifications()
    });
  }

  ngOnInit(): void {
    this.loadNotifications();
  }

  loadNotifications() {
    this.notificationService.getAllToday().subscribe({
      next: (result) => {
        this.todayNotifications = result;
      },
    });

    this.notificationService.getAllNotToday().subscribe({
      next: (result) => {
        this.otherNotifications = result;
      },
    });
  }
}
