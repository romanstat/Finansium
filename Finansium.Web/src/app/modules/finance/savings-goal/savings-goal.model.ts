export interface SavingsGoal {
  id: string;
  name: string;
  currentAmount: number;
  targetAmount: number;
  currency: string;
  note: string;
  startDate: Date;
  endDate: Date;
  completedDate?: Date;
  isCompleted: boolean;
}
