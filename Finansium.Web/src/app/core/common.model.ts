export interface User {
  id: string;
  country: string;
  currency: Currency;
  name: string;
  surname: string;
  patronymic?: string;
  email: string;
  username: string;
  createdAt: Date;
  roles: Role[];
}

export interface Role {
  id: number;
  name: string;
}

export enum TransactionType {
  Income = 'Income',
  Expense = 'Expense',
}

export interface Currency{
  code: string;
  name: string;
  sign: string;
}

export interface Country {
  id: string;
  shortName: string;
  fullName: string;
  alpha2Code: string;
  alpha3Code: string;
  numericCode: number;
}
