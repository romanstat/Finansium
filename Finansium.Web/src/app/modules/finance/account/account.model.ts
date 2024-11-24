export interface Account {
  id: string;
  name: string;
  balance: number;
  currency: string;
  createdAt: Date,
  modifiedAt: Date
}

export interface AccountTransfer{
  id: string;
  sourceAccount: string;
  targetAccount: string;
  amount: number;
  sourceCurrency: string;
  targetCurrency: string;
  currencyRate: number;
  date: Date;
}
