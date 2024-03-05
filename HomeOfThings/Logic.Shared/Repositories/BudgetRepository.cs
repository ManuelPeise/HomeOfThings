using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Date.Models.Entities.Finance;

namespace Logic.Shared.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private bool disposedValue;
        private readonly IRepositoryBase<BudgetAccount> _budgetAccountRepository;
        private readonly IRepositoryBase<BudgetDepartment> _budgetDepartmentRepository;
        private readonly IRepositoryBase<BudgetDepartmentAccount> _budgetDepartmentAccountRepository;
        
        public BudgetRepository(DatabaseContext context)
        {
            _budgetAccountRepository = new RepositoryBase<BudgetAccount>(context);
            _budgetDepartmentRepository = new RepositoryBase<BudgetDepartment>(context);
            _budgetDepartmentAccountRepository = new RepositoryBase<BudgetDepartmentAccount>(context);
        }

        public async Task<List<BudgetDepartmentAccount>> GetBudgetDepartmentAccounts(int userId)
        {
            var budgetDepartmentAccounts = await _budgetDepartmentAccountRepository.GetAllAsync(x => x.UserId == userId);

            if (budgetDepartmentAccounts.Any())
            {
                return budgetDepartmentAccounts.ToList();
            }

            return new List<BudgetDepartmentAccount>();
        }

        public async Task<BudgetAccount?> GetBudgetAccount(int accountId)
        {
           return await _budgetAccountRepository.GetFirstOrDefaultAsync(x => x.Id == accountId);
        }

        public async Task<BudgetDepartment?> GetBudgetDepartment(int departmentId)
        {
            return await _budgetDepartmentRepository.GetFirstOrDefaultAsync(x => x.Id == departmentId);
        }

        public async Task<bool> SaveBudgetDepartmentAccount(BudgetDepartmentAccount model)
        {
            return await _budgetDepartmentAccountRepository.Insert(model);
        }


        #region dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen
                }

                // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                // TODO: Große Felder auf NULL setzen
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
