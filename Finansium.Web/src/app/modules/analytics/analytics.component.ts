import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Analytic } from './analytics.model';
import { AnalyticsService } from './analytics.service';

@Component({
  selector: 'app-analytics',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.scss'],
})
export class AnalyticsComponent implements OnInit {
  analyticsService = inject(AnalyticsService);

  startDate: string = new Date().toISOString().split('T')[0];
  endDate: string = new Date().toISOString().split('T')[0];
  analytic!: Analytic;

  onDateRangeChange() {
    this.loadAnalytics();
  }

  ngOnInit(): void {
    this.loadAnalytics();
  }

  loadAnalytics() {
    this.analyticsService.get(this.startDate, this.endDate).subscribe({
      next: (result) => {
        this.analytic = result;
      },
    });
  }
}
