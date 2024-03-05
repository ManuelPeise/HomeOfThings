using Date.Models.Entities.Finance;

namespace Data.Interfaces.Interfaces.Repositories.Finances
{
    public interface IBudgetRepository : IDisposable
    {
        Task<List<BudgetDepartmentAccount>> GetBudgetDepartmentAccounts(int userId);
        Task<BudgetAccount?> GetBudgetAccount(int accountId);
        Task<BudgetDepartment?> GetBudgetDepartment(int departmentId);
        Task<bool> SaveBudgetDepartmentAccount(BudgetDepartmentAccount model)
    }
}
