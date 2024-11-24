export enum BudgetType{
  Weekly = 'Еженедельно',
  Monthly = 'Ежемесячно',
  Annual = 'Ежегодно'
}

export interface CategoryBudget{
  id: string;
  categoryId: string,
  name: string,
  type: BudgetType,
  limitAmount: number;
}