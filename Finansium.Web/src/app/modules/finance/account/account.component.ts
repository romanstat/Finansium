import { Component, inject } from '@angular/core';
import { Account, AccountTransfer } from './account.model';
import { AccountService } from './account.service';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Currency } from '../../../core/common.model';
import { CurrencyService } from '../../../core/services/currency.service';
import { AccountTransferService } from './account.transfer.service';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss',
})
export class AccountComponent {
  accountService = inject(AccountService);
  currencyService = inject(CurrencyService);
  accountTransfer = inject(AccountTransferService);

  accounts: Account[] = [];
  accountTransfers: AccountTransfer[] = [];
  editingAccount: Account | null = null;

  createForm: FormGroup;
  transferForm: FormGroup;
  currencies!: Currency[];

  constructor(private fb: FormBuilder) {
    this.currencyService.search().subscribe({
      next: (result) => {
        this.currencies = result;
      },
    });

    this.createForm = this.fb.group({
      name: new FormControl('', [Validators.required]),
      currency: new FormControl('USD', [Validators.required]),
      balance: new FormControl(0, [Validators.required]),
    });

    this.transferForm = this.fb.group({
      sourceAccountId: new FormControl('', [Validators.required]),
      targetAccountId: new FormControl('', [Validators.required]),
      amount: new FormControl(0, [Validators.required, Validators.min(0.01)]),
      currencyRate: new FormControl(1, [
        Validators.required,
        Validators.min(0.01),
      ]),
    });
  }

  getCurrency(name: string) : Currency{
    return this.currencies.find(c => c.name == name)!;
  }

  searchAccounts() {
    this.loadAccounts();
  }

  add(): void {
    this.accountService.create(this.createForm.value).subscribe({
      next: () => {
        this.loadAccounts();
      },
    });
  }

  transfer(): void {
    this.accountService.transfer(this.transferForm.value).subscribe({
      next: () => {
        this.loadAccounts();
        this.loadAccountTransfers();
      },
    });
  }

  isEditing(account: Account): boolean {
    return this.editingAccount?.id == account.id;
  }

  save(account: Account) {
    this.accountService.update(account).subscribe({
      next: () => {
        this.editingAccount = null;
      },
    });
  }

  edit(account: Account) {
    this.editingAccount = account;
  }

  cancelEditing() {
    this.editingAccount = null;
  }

  delete(id: string) {
    this.accountService.delete(id).subscribe(() => {
      this.loadAccounts();
    });
  }

  loadAccounts() {
    this.accountService.getAll().subscribe({
      next: (result) => {
        this.accounts = result;
      },
    });
  }

  loadAccountTransfers() {
    this.accountTransfer.getAll().subscribe({
      next: (result) => {
        this.accountTransfers = result;
      },
    });
  }

  ngOnInit(): void {
    this.loadAccounts();
    this.loadAccountTransfers();
  }
}
