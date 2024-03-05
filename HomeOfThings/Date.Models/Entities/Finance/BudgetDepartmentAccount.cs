using System.ComponentModel.DataAnnotations.Schema;

namespace Date.Models.Entities.Finance
{
    public class BudgetDepartmentAccount: AEntity
    {
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public BudgetAccount Account { get; set; } = new BudgetAccount();
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public BudgetDepartment Department { get; set; } = new BudgetDepartment();
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsPayment { get; set; }
    }
}
