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
  router = inject(Router);
  authService = inject(AuthService);

  isLoggedIn = true;
  isSidebarExpanded = false;

  logout() {
    this.isLoggedIn = false;
    this.authService.logout();
    this.router.navigate(['login']);
  }

  toggleSidebar(): void {
    this.isSidebarExpanded = !this.isSidebarExpanded;
  }

  ngOnInit(): void {
    if (!this.isLoggedIn) {
      this.router.navigate(['login']);
    } else {
      this.router.navigate(['profile']);
    }
  }
}
