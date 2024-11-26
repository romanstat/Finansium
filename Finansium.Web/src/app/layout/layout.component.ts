import { CommonModule } from '@angular/common';
import { Component, inject, Injector, OnInit } from '@angular/core';
import { RouterModule, RouterLink, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from '../core/common.model';
import { NotificationService } from '../modules/notification/notification.service';
import { RoleService } from '../auth/role.service';

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
  roleService = inject(RoleService);

  isLoggedIn = false;
  isSidebarExpanded = false;
  unreadCount = 0;
  private pollingIntervalId: any = null;

  logout() {
    this.isLoggedIn = false;
    this.authService.logout();
    clearInterval(this.pollingIntervalId);
    this.pollingIntervalId = null;
    this.router.navigate(['login']);
  }

  toggleSidebar(): void {
    this.isSidebarExpanded = !this.isSidebarExpanded;
  }

  private startPollingUnreadCount(): void {
    console.log(this.pollingIntervalId);
    if (this.pollingIntervalId == null) {
      this.pollingIntervalId = setInterval(() => {
        this.notificationService.updateUnreadCount();
      }, 5000);
    }
  }

  isAdmin(): boolean {
    return this.roleService.hasRole('Admin');
  }

  ngOnInit(): void {
    this.notificationService.unreadCount$.subscribe({
      next: (unreadCount) => {
        this.unreadCount = unreadCount!;
      },
    });

    this.authService.isLoggedIn$.subscribe({
      next: (loggedIn) => {
        this.isLoggedIn = loggedIn;
        if (!this.isLoggedIn) {
          this.router.navigate(['login']);
        } else {
          this.startPollingUnreadCount();
          this.router.navigate(['profile']);
        }
      },
    });
  }
}
