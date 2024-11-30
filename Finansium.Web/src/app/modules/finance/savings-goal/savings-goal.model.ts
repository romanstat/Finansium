import { Currency } from "../../../core/common.model";

export interface SavingsGoal {
  id: string;
  name: string;
  currentAmount: number;
  targetAmount: number;
  currency: Currency;
  note: string;
  startDate: Date;
  endDate: Date;
  completedDate?: Date;
  isCompleted: boolean;
}
