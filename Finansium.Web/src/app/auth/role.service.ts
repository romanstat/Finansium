import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { BehaviorSubject } from 'rxjs';
import { User } from '../core/common.model';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  private userSubject: BehaviorSubject<User | null>;

  constructor(private authService: AuthService) {
    this.userSubject = this.authService['userSubject'];
  }

  hasRole(role: string): boolean {
    const user = this.userSubject.getValue();

    return user ? user.roles.some((r) => r.name === role) : false;
  }

  hasAnyRole(roles: string[]): boolean {
    const user = this.userSubject.getValue();

    return user
      ? roles.some((role) => user.roles.some((r) => r.name === role))
      : false;
  }
}
