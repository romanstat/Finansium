import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../core/model/common.model';
import { Constants } from '../../core/constant';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  authService = inject(AuthService);

  user!: User;

  get userRoles(): string {
    return this.user.roles.map(x => x.name).join(', ');
  }

  ngOnInit(): void {
    this.user = this.authService.getUser();
  }
}
