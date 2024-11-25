export interface Transaction {
  id: string;
  type: string;
  categoryName: string;
  accountName: number;
  amount: number;
  currency: string;
  date: Date;
  description: string;
}
