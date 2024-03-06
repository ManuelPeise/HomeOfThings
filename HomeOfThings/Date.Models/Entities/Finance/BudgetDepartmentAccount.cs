using System.ComponentModel.DataAnnotations.Schema;

namespace Date.Models.Entities.Finance
{
    public class BudgetDepartmentAccount: AEntity
    {
        public int BudgetAccountId { get; set; }
        public int BudgetDepartmentId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsPayment { get; set; }
    }
}
