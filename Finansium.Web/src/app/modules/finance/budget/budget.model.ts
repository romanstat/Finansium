export enum BudgetType{
  Weekly = 'Weekly',
  Monthly = 'Monthly',
  Annual = 'Annual'
}

export interface CategoryBudget{
  id: string,
  name: string,
  type: BudgetType,
  limitAmount: number;
}