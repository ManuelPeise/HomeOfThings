namespace Date.Models.Entities.Finance
{
    public class BudgetDepartment: AEntity
    {
        public string Key { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public BudgetDepartmentAccount FinanceAccountDepartment { get; set; } = new BudgetDepartmentAccount();
    }
}
