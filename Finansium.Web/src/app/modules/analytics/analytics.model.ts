import { Currency } from "../../core/common.model";

export interface Analytic {
  currency: Currency;
  totalBalance: number;
  totalIncome: number;
  totalExpense: number;
  totalOperations: number;
  incomeCategoryAnalytics: IncomeCategoryAnalytic[];
  expenseCategoryAnalytics: IncomeCategoryAnalytic[];
}

export interface IncomeCategoryAnalytic {
  name: string;
  amount: number;
  totalOperations: number;
}
