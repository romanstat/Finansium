import { Currency } from "../../../core/common.model";

export interface Account {
  id: string;
  name: string;
  balance: number;
  currency: Currency;
  createdAt: Date,
  modifiedAt: Date
}

export interface AccountTransfer{
  id: string;
  sourceAccount: string;
  targetAccount: string;
  amount: number;
  sourceCurrency: Currency;
  targetCurrency: Currency;
  currencyRate: number;
  date: Date;
}
