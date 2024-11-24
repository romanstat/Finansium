import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../core/common.model';
import { Constants } from '../../core/constant';
import { AuthService } from '../../auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  authService = inject(AuthService);

  user!: User;

  get userRoles(): string {
    return this.user.roles.map((x) => x.name).join(', ');
  }

  ngOnInit(): void {
    this.authService.setUser();

    this.authService.user$.subscribe({
      next: (user) => {
        this.user = user!;
      },
    });
  }
}
