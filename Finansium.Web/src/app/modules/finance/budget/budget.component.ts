import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BudgetType, CategoryBudget } from './budget.model';
import { BudgetService } from './budget.service';

@Component({
  selector: 'app-budget',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './budget.component.html',
  styleUrl: './budget.component.scss',
})
export class BudgetComponent implements OnInit {
  budgetService = inject(BudgetService);

  currentBudgetType: BudgetType = BudgetType.Weekly;
  budgets: CategoryBudget[] = [];

  changeBudgetType(budgetType: string) {
    this.currentBudgetType = budgetType as BudgetType;
    
    this.loadBudgets();
  }

  loadBudgets() {
    this.budgetService.search(this.currentBudgetType).subscribe({
      next: (result) => {
        this.budgets = result;
      },
    });
  }

  bulkUpdate() {
    this.budgetService.bulkUpdate(this.budgets).subscribe({
      next: () => {
      },
    });
  }

  ngOnInit(): void {
    this.loadBudgets();
  }
}
