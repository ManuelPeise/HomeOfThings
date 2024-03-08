export interface IBudgetAccount extends IBudgetModelBase {
  departments: IBudgetDepartment[];
}

export interface IBudgetDepartment extends IBudgetModelBase {}

export interface IBudgetDepartmentAccount {
  budgetAccountId: number;
  budgetDepartmentId: number;
  userId: number;
  amount: number;
  tempAmount: string;
  isPayment: boolean;
  timestamp: number | null;
}

interface IBudgetModelBase {
  id: number;
  key: string;
}
