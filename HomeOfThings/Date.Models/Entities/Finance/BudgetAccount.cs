namespace Date.Models.Entities.Finance
{
    public class BudgetAccount: AEntity
    {
        public string Key { get; set; } = string.Empty;
        public BudgetDepartmentAccount FinanceAccountDepartment { get; set; } = new BudgetDepartmentAccount();

    }
}
