import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../core/model/common.model';
import { CommonModule } from '@angular/common';
import { News } from './news.model';
import { NewsService } from './news.service';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './news.component.html',
  styleUrl: './news.component.scss',
})
export class NewsComponent implements OnInit {
  authService = inject(AuthService);
  newsService = inject(NewsService);

  user!: User;
  news: News[] = [];

  delete(id: string) {
    this.newsService.delete(id);
  }

  ngOnInit(): void {
    this.user = this.authService.getUser();
  }
}
