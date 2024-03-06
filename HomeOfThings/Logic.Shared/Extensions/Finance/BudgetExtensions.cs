using Date.Models.Entities.Finance;
using Date.Models.Models.Finance;

namespace Logic.Shared.Extensions.Finance
{
    public static class BudgetExtensions
    {
        public static BudgetAccountEntity ToEntity(this BudgetAccount account)
        {
            return new BudgetAccountEntity
            {
                Id = account.Id,
                Key = account.Key,
            };
        }

        public static BudgetDepartmentEntity ToEntity(this BudgetDepartment department, int parentAccountId)
        {
            return new BudgetDepartmentEntity
            {
                Id = department.Id,
                Key = department.Key,
                ParentAccountId = parentAccountId
            };
        }

        public static BudgetAccount ToModel(this BudgetAccountEntity entity)
        {
            return new BudgetAccount
            {
                Id = entity.Id,
                Key = entity.Key,
            };
        }

        public static BudgetDepartment ToModel(this BudgetDepartmentEntity department)
        {
            return new BudgetDepartment
            {
                Id = department.Id,
                Key = department.Key,
                
            };
        }
    }
}
