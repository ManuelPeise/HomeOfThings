using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Date.Models.Entities.Finance;
using Date.Models.Models.Finance;
using Logic.Shared.Extensions.Finance;

namespace Logic.Shared.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private bool disposedValue;
        private readonly IRepositoryBase<BudgetAccountEntity> _budgetAccountRepository;
        private readonly IRepositoryBase<BudgetDepartmentEntity> _budgetDepartmentRepository;
        private readonly IRepositoryBase<BudgetDepartmentAccountEntity> _budgetDepartmentAccountRepository;

        public BudgetRepository(DatabaseContext context)
        {
            _budgetAccountRepository = new RepositoryBase<BudgetAccountEntity>(context);
            _budgetDepartmentRepository = new RepositoryBase<BudgetDepartmentEntity>(context);
            _budgetDepartmentAccountRepository = new RepositoryBase<BudgetDepartmentAccountEntity>(context);
        }

        public async Task<bool> ImportAccount(BudgetAccount account)
        {
            if (account != null)
            {
                var accountEntity = account.ToEntity();

                if (await _budgetAccountRepository.InsertIfNotExists(accountEntity, x => x.Key.Equals(account.Key)))
                {
                    foreach (var department in account.Departments)
                    {
                        if (department != null)
                        {
                            var departmentEntity = department.ToEntity(account.Id);

                            await _budgetDepartmentRepository.InsertIfNotExists(departmentEntity, x => x.Id == department.Id);
                        }
                    }

                }

                return true;
            }

            return false;
        }

        public async Task<bool> ImportAccountDepartment(BudgetAccountDepartment accountDepartment)
        {
            if(accountDepartment != null)
            {
                var entity = accountDepartment.ToEntity();

                return await _budgetDepartmentAccountRepository.Insert(entity);
            }

            return false;
        }
        public async Task<List<BudgetAccountEntity>> GetBudgetAccounts()
        {
            var accountEntities = await _budgetAccountRepository.GetAllAsync();

            return accountEntities.ToList();
        }

        public async Task<List<BudgetDepartmentAccountEntity>> GetBudgetDepartmentAccounts(int userId)
        {
            var budgetDepartmentAccounts = await _budgetDepartmentAccountRepository.GetAllAsync(x => x.UserId == userId);

            if (budgetDepartmentAccounts.Any())
            {
                return budgetDepartmentAccounts.ToList();
            }

            return new List<BudgetDepartmentAccountEntity>();
        }

        public async Task<BudgetAccountEntity?> GetBudgetAccount(int accountId)
        {
            return await _budgetAccountRepository.GetFirstOrDefaultAsync(x => x.Id == accountId);
        }

        public async Task<BudgetDepartmentEntity?> GetBudgetDepartment(int departmentId)
        {
            return await _budgetDepartmentRepository.GetFirstOrDefaultAsync(x => x.Id == departmentId);
        }

        public async Task<IEnumerable<BudgetDepartmentEntity>> GetBudgetAccountDepartments(int accountId)
        {
            return await _budgetDepartmentRepository.GetAllAsync(x => x.ParentAccountId == accountId);
        }

        public async Task<bool> SaveBudgetDepartmentAccount(BudgetDepartmentAccountEntity model)
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
