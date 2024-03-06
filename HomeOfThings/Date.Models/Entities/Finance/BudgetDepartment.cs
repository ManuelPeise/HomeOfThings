namespace Date.Models.Entities.Finance
{
    public class BudgetDepartment: AEntity
    {
        public string Key { get; set; } = string.Empty;
        public int ParentAccountId { get; set; }
    }
}
