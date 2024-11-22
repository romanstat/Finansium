import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Constants } from '../../../core/constant';
import { Country, User } from '../../../core/common.model';
import { CommonModule } from '@angular/common';
import { UserService } from './user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent implements OnInit {
  userService = inject(UserService);

  users: User[] = [];
  searchTerm: string = '';
  editingUser: User | null = null;

  isEditing(user: User): boolean {
    return this.editingUser?.id == user.id;
  }

  save(user: User) {
    this.editingUser = null;

    this.userService.update(user).subscribe(() => {
      this.search();
    });
  }

  edit(user: User) {
    this.editingUser = user;
  }

  cancelEdit() {
    this.editingUser = null;
  }

  search() {
    this.userService.getAll(this.searchTerm).subscribe((result) => {
      this.users = result;
    });
  }

  ngOnInit(): void {
    this.search();
  }
}
