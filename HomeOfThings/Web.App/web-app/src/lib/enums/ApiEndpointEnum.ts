export enum ApiEndpointEnum {
  PostLogin = 'AuthenticationService/UserLogin',
  PostRegistration = 'AuthenticationService/UserLogout',
  GetBudgetAccounts = 'BudgetAccounting/LoadBudgetAccounts',
  GetFamilyMembers = 'FamilyAdministration/GetFamilies',
  SaveFamily = 'FamilyAdministration/RegisterFamily',
  UpdateFamily = 'FamilyAdministration/UpdateFamily',
  ImportBudgetAccountDepartment = 'BudgetAccounting/ImportAccountDepartment',
  GetLogMessages = 'Log/GetLogMessages',
}
