import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-savings-goal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './savings-goal.component.html',
  styleUrl: './savings-goal.component.scss'
})
export class SavingsGoalComponent implements OnInit {
  // Список целей
  goals = [
    { id: 1, name: 'Новая машина', targetAmount: 10000, collectedAmount: 2000, currency: 'USD', isCompleted: false, startDate: '2024-01-01', endDate: '2024-12-31' },
    { id: 2, name: 'Путешествие', targetAmount: 5000, collectedAmount: 5000, currency: 'USD', isCompleted: true, startDate: '2023-01-01', endDate: '2023-12-31' }
  ];

  // Форма для создания цели
  createForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    // Инициализация формы для создания новой цели
    this.createForm = this.fb.group({
      name: ['', [Validators.required]], // Название цели
      targetAmount: [0, [Validators.required, Validators.min(0.01)]], // Целевая сумма > 0
      currency: ['USD', [Validators.required]], // Валюта
      startDate: ['', Validators.required], // Дата начала
      endDate: ['', Validators.required] // Дата окончания
    });
  }

  // Метод для создания новой цели
  onCreateGoalSubmit(): void {
    if (this.createForm.valid) {
      const newGoal = {
        ...this.createForm.value,
        id: this.goals.length ? Math.max(...this.goals.map(goal => goal.id)) + 1 : 1,
        collectedAmount: 0, // Новая цель всегда начинается с 0
        isCompleted: false // Новая цель всегда в статусе "В процессе"
      };
      this.goals.push(newGoal);
      this.createForm.reset({ currency: 'USD', targetAmount: 0 }); // Сброс формы
      alert('Цель успешно добавлена!');
    }
  }

  // Метод для удаления цели
  deleteGoal(goalId: number): void {
    this.goals = this.goals.filter(goal => goal.id !== goalId);
    alert(`Цель с ID ${goalId} удалена`);
  }
}