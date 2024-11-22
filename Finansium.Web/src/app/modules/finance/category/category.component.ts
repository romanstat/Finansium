import { Component, inject, isDevMode, OnInit } from '@angular/core';
import { CategoryService } from './category.service';
import { Category } from './category.model';
import { TransactionType } from '../../../core/common.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.scss',
})
export class CategoryComponent implements OnInit {
  categoryService = inject(CategoryService);

  expenseCategories: Category[] = [];
  incomeCategories: Category[] = [];
  editingCategory: Category | null = null;

  addExpense() {
    const newCategory: Category = { id: '', name: '' };

    this.categoryService.createExpense(newCategory).subscribe((result) => {
      newCategory.id = result;
      this.expenseCategories.push(newCategory);
      this.edit(newCategory);
    });
  }

  addIncome() {
    const newCategory: Category = { id: '', name: '' };

    this.categoryService.createIncome(newCategory).subscribe((result) => {
      newCategory.id = result;
      this.incomeCategories.push(newCategory);
      this.edit(newCategory);
    });

    this.edit(newCategory);
  }

  isEditing(category: Category): boolean {
    return this.editingCategory?.id == category.id;
  }

  save(category: Category) {
    this.editingCategory = null;

    this.categoryService.update(category).subscribe(() => {
      this.loadCategories();
    });
  }

  edit(category: Category) {
    this.editingCategory = category;
  }

  cancelEdit() {
    this.editingCategory = null;
  }

  delete(id: string) {
    this.categoryService.delete(id).subscribe(() => {
      this.loadCategories();
    });
  }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.search(TransactionType.Expense).subscribe((result) => {
      this.expenseCategories = result;
    });

    this.categoryService.search(TransactionType.Income).subscribe((result) => {
      this.incomeCategories = result;
    });
  }
}
