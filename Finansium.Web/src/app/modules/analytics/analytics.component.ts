import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-analytics',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.scss']
})
export class AnalyticsComponent implements OnInit {
  currency = 'USD'; // Валюта
  selectedPeriod: Period = 'week'; // По умолчанию "Неделя"

  metrics = {
    totalIncome: 0,
    totalExpenses: 0,
    totalTransactions: 0,
    topExpenseCategories: [] as { name: string; amount: number; count: number }[],
    topIncomeCategories: [] as { name: string; amount: number; count: number }[]
  };

  data: Record<Period, {
    totalIncome: number;
    totalExpenses: number;
    totalTransactions: number;
    topExpenseCategories: { name: string; amount: number; count: number }[];
    topIncomeCategories: { name: string; amount: number; count: number }[];
  }> = {
    week: {
      totalIncome: 1000,
      totalExpenses: 800,
      totalTransactions: 10,
      topExpenseCategories: [
        { name: 'Еда', amount: 300, count: 5 },
        { name: 'Транспорт', amount: 200, count: 2 },
        { name: 'Развлечения', amount: 150, count: 1 },
        { name: 'Коммунальные услуги', amount: 100, count: 1 },
        { name: 'Медицина', amount: 50, count: 1 }
      ],
      topIncomeCategories: [
        { name: 'Зарплата', amount: 800, count: 1 },
        { name: 'Бизнес', amount: 200, count: 1 }
      ]
    },
    month: {
      totalIncome: 4000,
      totalExpenses: 3000,
      totalTransactions: 50,
      topExpenseCategories: [
        { name: 'Еда', amount: 1200, count: 15 },
        { name: 'Транспорт', amount: 800, count: 10 },
        { name: 'Развлечения', amount: 500, count: 5 },
        { name: 'Коммунальные услуги', amount: 300, count: 4 },
        { name: 'Медицина', amount: 200, count: 2 }
      ],
      topIncomeCategories: [
        { name: 'Зарплата', amount: 3200, count: 2 },
        { name: 'Бизнес', amount: 800, count: 4 }
      ]
    },
    quarter: {
      totalIncome: 12000,
      totalExpenses: 9000,
      totalTransactions: 150,
      topExpenseCategories: [
        { name: 'Еда', amount: 3600, count: 45 },
        { name: 'Транспорт', amount: 2400, count: 30 },
        { name: 'Развлечения', amount: 1500, count: 20 },
        { name: 'Коммунальные услуги', amount: 900, count: 12 },
        { name: 'Медицина', amount: 600, count: 10 }
      ],
      topIncomeCategories: [
        { name: 'Зарплата', amount: 9600, count: 6 },
        { name: 'Бизнес', amount: 2400, count: 12 }
      ]
    },
    year: {
      totalIncome: 50000,
      totalExpenses: 45000,
      totalTransactions: 500,
      topExpenseCategories: [
        { name: 'Еда', amount: 15000, count: 180 },
        { name: 'Транспорт', amount: 12000, count: 150 },
        { name: 'Развлечения', amount: 7500, count: 90 },
        { name: 'Коммунальные услуги', amount: 4500, count: 60 },
        { name: 'Медицина', amount: 3000, count: 40 }
      ],
      topIncomeCategories: [
        { name: 'Зарплата', amount: 40000, count: 24 },
        { name: 'Бизнес', amount: 10000, count: 24 }
      ]
    },
    all: {
      totalIncome: 100000,
      totalExpenses: 90000,
      totalTransactions: 1000,
      topExpenseCategories: [
        { name: 'Еда', amount: 30000, count: 360 },
        { name: 'Транспорт', amount: 24000, count: 300 },
        { name: 'Развлечения', amount: 15000, count: 180 },
        { name: 'Коммунальные услуги', amount: 9000, count: 120 },
        { name: 'Медицина', amount: 6000, count: 80 }
      ],
      topIncomeCategories: [
        { name: 'Зарплата', amount: 80000, count: 48 },
        { name: 'Бизнес', amount: 20000, count: 48 }
      ]
    }
  };

  ngOnInit(): void {
    this.updateMetrics();
  }

  onPeriodChange(): void {
    this.updateMetrics();
  }

  updateMetrics(): void {
    const periodData = this.data[this.selectedPeriod];
    this.metrics = {
      totalIncome: periodData.totalIncome,
      totalExpenses: periodData.totalExpenses,
      totalTransactions: periodData.totalTransactions,
      topExpenseCategories: periodData.topExpenseCategories,
      topIncomeCategories: periodData.topIncomeCategories
    };
  }
}

type Period = 'week' | 'month' | 'quarter' | 'year' | 'all';