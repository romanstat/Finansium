export interface User {
  id: string;
  country: string;
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

export interface Country {
  id: string;
  shortName: string;
  fullName: string;
  alpha2Code: string;
  alpha3Code: string;
  numericCode: number;
}
