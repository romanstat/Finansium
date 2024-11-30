import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Currency } from '../../../core/common.model';
import { CurrencyService } from '../../../core/services/currency.service';
import { SavingsGoal } from './savings-goal.model';
import { SavingsGoalService } from './savings-goal.service';
import { Account } from '../account/account.model';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-savings-goal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './savings-goal.component.html',
  styleUrl: './savings-goal.component.scss',
})
export class SavingsGoalComponent implements OnInit {
  currencyService = inject(CurrencyService);
  savingsGoalService = inject(SavingsGoalService);
  accountService = inject(AccountService);

  currencies!: Currency[];
  savingsGoals: SavingsGoal[] = [];
  accounts: Account[] = [];
  accountCurrency?: Currency;

  editingSavingsGoal: SavingsGoal | null = null;
  createForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm = this.fb.group({
      accountId: ['', [Validators.required]],
      name: ['', [Validators.required]],
      targetAmount: [0, [Validators.required, Validators.min(0.01)]],
      currency: ['USD', [Validators.required]],
      note: [''],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
    });
  }

  onAccountChange(event: Event) {
    const selectedAccountId = (event.target as HTMLSelectElement).value;
    const selectedAccount = this.accounts.find(
      (account) => account.id === selectedAccountId
    );

    if (selectedAccount) {
      this.accountCurrency = selectedAccount.currency;
    }
  }

  ngOnInit(): void {
    this.currencyService.search().subscribe({
      next: (result) => {
        this.currencies = result;
      },
    });

    this.accountService.getAll().subscribe({
      next: (result) => {
        this.accounts = result;
      },
    });

    this.loadSavingsGoals();
  }

  create(): void {
    this.savingsGoalService.create(this.createForm.value).subscribe({
      next: () => {
        this.loadSavingsGoals();
      },
    });
  }

  delete(id: string): void {
    this.savingsGoalService.delete(id).subscribe({
      next: () => {
        this.loadSavingsGoals();
      },
    });
  }

  loadSavingsGoals() {
    this.savingsGoalService.getAll().subscribe({
      next: (result) => {
        this.savingsGoals = result;
      },
    });
  }

  isEditing(savingsGoal: SavingsGoal): boolean {
    return this.editingSavingsGoal?.id == savingsGoal.id;
  }

  save(savingsGoal: SavingsGoal) {
    this.savingsGoalService.update(savingsGoal).subscribe({
      next: () => {
        this.editingSavingsGoal = null;
        this.loadSavingsGoals();
      },
    });
  }

  edit(savingsGoal: SavingsGoal) {
    this.editingSavingsGoal = savingsGoal;
  }

  cancelEditing() {
    this.editingSavingsGoal = null;
  }
}
