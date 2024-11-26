import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Account } from '../account/account.model';
import { AccountService } from '../account/account.service';
import { RecurringTransactionService } from './recurring-transaction.service';
import { RecurringTransaction } from './recurring-transaction.model';

@Component({
  selector: 'app-recurring-transaction',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './recurring-transaction.component.html',
  styleUrl: './recurring-transaction.component.scss',
})
export class RecurringTransactionComponent implements OnInit {
  accountService = inject(AccountService);
  recurringTransactionService = inject(RecurringTransactionService);

  accounts: Account[] = [];
  recurringTransactions: RecurringTransaction[] = [];

  createForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm = this.fb.group({
      accountId: ['', [Validators.required]],
      amount: [0, [Validators.required, Validators.min(0.01)]],
      type: ['', [Validators.required]],
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      description: [''],

      interval: ['Monthly', [Validators.required]],
    });
  }

  create(): void {
    const formValue = this.createForm.value;

    const timeSpanInterval = this.mapIntervalToTimeSpan(formValue.interval);

    const payload = {
      ...formValue,
      interval: timeSpanInterval,
    };
    console.log(payload);
    this.recurringTransactionService.create(payload).subscribe({
      next: () => {
        this.loadRecurringTransaction();
      },
    });
  }

  delete(id: string): void {
    this.recurringTransactionService.delete(id).subscribe({
      next: () => {
        this.loadRecurringTransaction();
      },
    });
  }

  ngOnInit(): void {
    this.accountService.getAll().subscribe({
      next: (result) => {
        this.accounts = result;
      },
    });

    this.loadRecurringTransaction();
  }

  loadRecurringTransaction() {
    this.recurringTransactionService.search().subscribe({
      next: (result) => {
        this.recurringTransactions = result;
      },
    });
  }

  mapIntervalToTimeSpan(interval: string): string {
    switch (interval) {
      case 'Daily':
        return '1.00:00:00';
      case 'Weekly':
        return '7.00:00:00';
      case 'Monthly':
        return '30.00:00:00';
      case 'Yearly':
        return '365.00:00:00';
      default:
        throw new Error('Invalid interval');
    }
  }
}
