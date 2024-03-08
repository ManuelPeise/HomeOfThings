using Date.Models.Entities.Finance;
using Date.Models.Models.Finance;

namespace Data.Interfaces.Interfaces.Repositories.Finances
{
    public interface IBudgetRepository : IDisposable
    {
        Task<bool> ImportAccount(BudgetAccount account);
        Task<bool> ImportAccountDepartment(BudgetAccountDepartment accountDepartment);
        Task<List<BudgetAccountEntity>> GetBudgetAccounts();
        Task<List<BudgetDepartmentAccountEntity>> GetBudgetDepartmentAccounts(int userId);
        Task<BudgetAccountEntity?> GetBudgetAccount(int accountId);
        Task<BudgetDepartmentEntity?> GetBudgetDepartment(int departmentId);
        Task<IEnumerable<BudgetDepartmentEntity>> GetBudgetAccountDepartments(int accountId);

        Task<bool> SaveBudgetDepartmentAccount(BudgetDepartmentAccountEntity model);
    }
}
