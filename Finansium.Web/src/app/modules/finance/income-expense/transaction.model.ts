import { Currency } from "../../../core/common.model";

export interface Transaction {
  id: string;
  type: string;
  categoryName: string;
  accountName: number;
  amount: number;
  currency: Currency;
  date: Date;
  description: string;
}
