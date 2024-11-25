import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
  FormsModule,
} from '@angular/forms';
import { Transaction } from './transaction.model';
import { TransactionService } from './transaction.service';
import { TransactionType } from '../../../core/common.model';
import { Category } from '../category/category.model';
import { CategoryService } from '../category/category.service';
import { AccountService } from '../account/account.service';
import { Account } from '../account/account.model';

@Component({
  selector: 'app-income-expense',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './income-expense.component.html',
  styleUrl: './income-expense.component.scss',
})
export class IncomeExpenseComponent implements OnInit {
  transactionService = inject(TransactionService);
  categoryService = inject(CategoryService);
  accountService = inject(AccountService);
  
  transactions: Transaction[] = [];
  categories: Category[] = [];
  accounts: Account[] = [];

  createForm: FormGroup;
  transactionType: TransactionType = TransactionType.Income;

  constructor(private fb: FormBuilder) {
    this.createForm = this.fb.group({
      categoryId: ['', [Validators.required]],
      accountId: ['', [Validators.required]], 
      type: ['', [Validators.required]],
      amount: [0, [Validators.required]],
      description: [''],
      date: ['', [Validators.required]],
    });
  }

  onTransactionTypeChange(event: Event) {
    const selectedTransactionType = (event.target as HTMLSelectElement).value;

    this.transactionType = selectedTransactionType as TransactionType;

    this.loadCategories();
  }

  create(): void {
    if (this.transactionType == TransactionType.Income) {
      this.transactionService.createIncome(this.createForm.value).subscribe({
        next: () => {
          this.loadTransacations();
        },
      });
    } else {
      this.transactionService.createExpense(this.createForm.value).subscribe({
        next: () => {
          this.loadTransacations();
        },
      });
    }
  }

  delete(id: string): void {
    this.transactionService.delete(id).subscribe({
      next: () => {
        this.loadTransacations();
      },
    });
  }

  ngOnInit(): void {
    this.loadTransacations();

    this.loadCategories();

    this.accountService.getAll().subscribe({
      next: (result) => {
        this.accounts = result;
      },
    });
  }

  loadTransacations() {
    this.transactionService.search().subscribe({
      next: (result) => {
        this.transactions = result;
      },
    });
  }

  loadCategories(): void {
    this.categoryService.search(this.transactionType).subscribe((result) => {
      this.categories = result;
    });
  }
}
