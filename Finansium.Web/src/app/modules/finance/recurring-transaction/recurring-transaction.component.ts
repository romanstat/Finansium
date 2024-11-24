import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-recurring-transaction',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './recurring-transaction.component.html',
  styleUrl: './recurring-transaction.component.scss'
})
export class RecurringTransactionComponent implements OnInit {
  // Список повторяющихся платежей
  recurringPayments = [
    {
      id: 1,
      name: 'Аренда квартиры',
      amount: 500,
      currency: 'USD',
      interval: 'Monthly',
      startDate: '2024-01-01',
      endDate: '2024-12-31',
      nextPaymentDate: '2024-01-15'
    },
    {
      id: 2,
      name: 'Абонемент в спортзал',
      amount: 50,
      currency: 'USD',
      interval: 'Monthly',
      startDate: '2024-02-01',
      endDate: '2024-12-31',
      nextPaymentDate: '2024-02-15'
    }
  ];

  // Форма для создания повторяющегося платежа
  createRecurringPaymentForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    // Инициализация формы для создания нового повторяющегося платежа
    this.createRecurringPaymentForm = this.fb.group({
      name: ['', [Validators.required]], // Название платежа
      amount: [0, [Validators.required, Validators.min(0.01)]], // Сумма > 0
      currency: ['USD', [Validators.required]], // Валюта
      interval: ['Monthly', [Validators.required]], // Интервал
      startDate: ['', [Validators.required]], // Дата начала
      endDate: ['', [Validators.required]] // Дата окончания
    });
  }

  // Метод для создания нового повторяющегося платежа
  onCreateRecurringPaymentSubmit(): void {
    if (this.createRecurringPaymentForm.valid) {
      const newPayment = {
        ...this.createRecurringPaymentForm.value,
        id: this.recurringPayments.length ? Math.max(...this.recurringPayments.map(payment => payment.id)) + 1 : 1,
        nextPaymentDate: this.calculateNextPaymentDate(this.createRecurringPaymentForm.value.startDate, this.createRecurringPaymentForm.value.interval)
      };
      this.recurringPayments.push(newPayment);
      this.createRecurringPaymentForm.reset({ currency: 'USD', interval: 'Monthly', amount: 0 }); // Сброс формы
      alert('Повторяющийся платеж успешно добавлен!');
    }
  }

  // Удаление повторяющегося платежа
  deleteRecurringPayment(paymentId: number): void {
    this.recurringPayments = this.recurringPayments.filter(payment => payment.id !== paymentId);
    alert(`Повторяющийся платеж с ID ${paymentId} удален`);
  }

  // Расчет следующей даты платежа
  calculateNextPaymentDate(startDate: string, interval: string): string {
    const date = new Date(startDate);
    switch (interval) {
      case 'Daily':
        date.setDate(date.getDate() + 1);
        break;
      case 'Weekly':
        date.setDate(date.getDate() + 7);
        break;
      case 'Monthly':
        date.setMonth(date.getMonth() + 1);
        break;
      case 'Yearly':
        date.setFullYear(date.getFullYear() + 1);
        break;
    }
    return date.toISOString().split('T')[0]; // Форматируем дату в ISO
  }
}