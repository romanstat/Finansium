import { TransactionType } from "../../../core/common.model";

export interface RecurringTransaction {
  id: string;
  accountName: string;
  amount: number;
  type: TransactionType;
  interval: string;
  startDate: Date;
  endDate: Date;
  nextPaymentDate?: Date;
  description: string;
}
