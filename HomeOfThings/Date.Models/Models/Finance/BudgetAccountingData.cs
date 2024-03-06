namespace Date.Models.Models.Finance
{
    public class BudgetAccountingData
    {
        public List<BudgetAccount> BudgetAccounts { get; set; } = new List<BudgetAccount>();
    }

    public class BudgetAccount: BudgetModelBase
    {
        public List<BudgetDepartment> Departments { get; set; } = new List<BudgetDepartment>();
    }

    public class BudgetDepartment: BudgetModelBase
    {

    }

    public class BudgetModelBase
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
    }
}
