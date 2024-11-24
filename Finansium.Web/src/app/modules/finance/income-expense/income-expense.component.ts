import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-income-expense',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './income-expense.component.html',
  styleUrl: './income-expense.component.scss'
})
export class IncomeExpenseComponent implements OnInit {
  // Список категорий (можно заменить на данные из базы)
  categories = ['Еда', 'Транспорт', 'Зарплата', 'Развлечения', 'Коммунальные услуги'];

  // Список транзакций
  transactions = [
    { id: 1, type: 'income', amount: 1000, category: 'Зарплата', date: '2024-01-01', note: 'Премия' },
    { id: 2, type: 'expense', amount: 50, category: 'Еда', date: '2024-01-02', note: 'Обед в кафе' }
  ];

  // Форма для добавления транзакции
  transactionForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    // Инициализация формы
    this.transactionForm = this.fb.group({
      type: ['income', [Validators.required]], // Доход или Расход
      amount: [0, [Validators.required, Validators.min(0.01)]], // Сумма > 0
      category: ['', [Validators.required]], // Категория
      date: ['', [Validators.required]], // Дата
      note: [''] // Примечание
    });
  }

  // Метод для добавления транзакции
  onAddTransaction(): void {
    if (this.transactionForm.valid) {
      const newTransaction = {
        ...this.transactionForm.value,
        id: this.transactions.length ? Math.max(...this.transactions.map(t => t.id)) + 1 : 1
      };
      this.transactions.push(newTransaction);
      this.transactionForm.reset({ type: 'income', amount: 0 }); // Сброс формы
      alert('Транзакция добавлена!');
    }
  }

  // Удаление транзакции
  deleteTransaction(transactionId: number): void {
    this.transactions = this.transactions.filter(transaction => transaction.id !== transactionId);
    alert(`Транзакция с ID ${transactionId} удалена`);
  }
}