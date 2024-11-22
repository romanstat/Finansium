import { Component, inject } from '@angular/core';
import { Account } from './account.model';
import { AccountService } from './account.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss',
})
export class AccountComponent {
  accountService = inject(AccountService);

  accounts: Account[] = [];

  ngOnInit(): void {
    this.loadAccounts();
  }

  searchAccounts() {
    this.loadAccounts();
  }

  loadAccounts() {
    this.accountService.getAll().subscribe({
      next: (result) => {
        this.accounts = result;
      },
    });
  }
}
