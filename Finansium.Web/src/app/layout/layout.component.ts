import { CommonModule } from '@angular/common';
import { Component, inject, Injector, OnInit } from '@angular/core';
import { RouterModule, RouterLink, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from '../core/model/common.model';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterModule, CommonModule, RouterLink],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
})
export class LayoutComponent implements OnInit {
  injector = inject(Injector);
  router = inject(Router);
  authService = inject(AuthService);

  user: User | null = null;
  isLoggedIn = false;
  isSidebarExpanded = false;

  logout() {
    this.authService.logout();
    this.checkAuthStatus();
  }

  ngOnInit(): void {
    this.checkAuthStatus();
  }

  checkAuthStatus(): void {
    this.user = this.authService.getUserInfo();
  }

  toggleSidebar(): void {
    this.isSidebarExpanded = !this.isSidebarExpanded;
  }
}
