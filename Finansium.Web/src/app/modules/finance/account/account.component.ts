import { Component, inject } from '@angular/core';
import { Account, AccountTransfer } from './account.model';
import { AccountService } from './account.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss',
})
export class AccountComponent {
  accountService = inject(AccountService);

  accounts: Account[] = [];
  accountTransfers: AccountTransfer[] = [];
  editingAccount: Account | null = null;

  createForm: FormGroup;
  transferForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm = this.fb.group({
      name: new FormControl('', [Validators.required]),
      currency: new FormControl('USD', [Validators.required]),
      balance: new FormControl(0, [Validators.required])
    });

    this.transferForm = this.fb.group({
      sourceAccount: new FormControl('', [Validators.required]),
      targetAccount: new FormControl('', [Validators.required]), 
      amount: new FormControl(0, [Validators.required, Validators.min(0.01)]),
      currencyRate: new FormControl(1, [Validators.required, Validators.min(0.01)])
    });
  }

  ngOnInit(): void {
    this.loadAccounts();
  }

  searchAccounts() {
    this.loadAccounts();
  }

  add(): void {}

  transfer(): void {}

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
}
