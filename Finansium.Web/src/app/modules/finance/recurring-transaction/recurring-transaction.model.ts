export interface RecurringTransaction {
  id: string;
  accountName: string;
  amount: number;
  type: string;
  interval: string;
  startDate: Date;
  endDate: Date;
  nextPaymentDate?: Date;
  description: string;
}
