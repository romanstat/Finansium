import { CommonModule } from '@angular/common';
import { Component, inject, Injector, OnInit } from '@angular/core';
import { RouterModule, RouterLink, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from '../core/common.model';
import { NotificationService } from '../modules/notification/notification.service';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterModule, CommonModule, RouterLink],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
})
export class LayoutComponent implements OnInit {
  router = inject(Router);
  authService = inject(AuthService);
  notificationService = inject(NotificationService);

  isLoggedIn = false;
  isSidebarExpanded = false;
  unreadCount = 0;

  logout() {
    this.isLoggedIn = false;
    this.authService.logout();
    this.router.navigate(['login']);
  }

  toggleSidebar(): void {
    this.isSidebarExpanded = !this.isSidebarExpanded;
  }

  private startPollingUnreadCount(): void {
    setInterval(() => {
      this.notificationService.updateUnreadCount();
    }, 5000);
  }

  ngOnInit(): void {
    this.notificationService.unreadCount$.subscribe({
      next: (unreadCount) => {
        this.unreadCount = unreadCount!;
      },
    });

    this.startPollingUnreadCount();

    this.authService.isLoggedIn$.subscribe({
      next: (loggedIn) => {
        this.isLoggedIn = loggedIn;
        if (!this.isLoggedIn) {
          this.router.navigate(['login']);
        } else {
          this.router.navigate(['profile']);
        }
      },
    });
  }
}
