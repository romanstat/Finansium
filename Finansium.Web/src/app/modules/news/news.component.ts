import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../core/common.model';
import { CommonModule } from '@angular/common';
import { News } from './news.model';
import { NewsService } from './news.service';
import { RoleService } from '../../auth/role.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './news.component.html',
  styleUrl: './news.component.scss',
})
export class NewsComponent implements OnInit {
  authService = inject(AuthService);
  newsService = inject(NewsService);
  roleService = inject(RoleService);

  user!: User;
  news: News[] = [];

  saveForm!: FormGroup;
  isEditing: boolean = false;
  modalTitle: string = '';

  constructor(private fb: FormBuilder) {
    this.saveForm = this.fb.group({
      id: new FormControl(''),
      title: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.authService.user$.subscribe({
      next: (user) => {
        this.user = user!;
      },
    });

    this.refreshNews();
  }

  isAdmin(): boolean {
    return this.roleService.hasRole('Admin');
  }

  openEditModal(newsItem: News): void {
    this.isEditing = true;
    this.modalTitle = 'Редактировать новость';
    this.saveForm.patchValue({
      id: newsItem.id,
      title: newsItem.title,
      description: newsItem.description,
    });
  }

  openCreateModal(): void {
    this.isEditing = false;
    this.modalTitle = 'Создать новость';
  }

  onSubmit(): void {
    if (this.isEditing) {
      this.newsService.update(this.saveForm.value).subscribe({
        next: () => {
          this.refreshNews();
        },
      });
    } else {
      this.newsService.create(this.saveForm.value).subscribe({
        next: () => {
          this.refreshNews();
        },
      });
    }

    this.saveForm.reset();
  }

  outdate(id: string) {
    this.newsService.outdate(id).subscribe({
      next: () => {
        this.refreshNews();
      },
    });
  }

  refreshNews() {
    this.newsService.getAll().subscribe({
      next: (result) => {
        this.news = result;
      },
    });
  }
}
