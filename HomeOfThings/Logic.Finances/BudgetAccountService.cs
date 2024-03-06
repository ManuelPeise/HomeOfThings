using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Date.Models.Entities.Log;
using Date.Models.Models.Finance;
using Logic.Shared;
using Logic.Shared.Extensions.Finance;
using Microsoft.AspNetCore.Http;

namespace Logic.Finances
{
    public class BudgetAccountService : ALogicBase, IDisposable
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly HttpContext _httpContext;
        private bool disposedValue;

        public BudgetAccountService(IBudgetRepository budgetRepository, IHttpContextAccessor httpContextAccessor, DatabaseContext context) : base(context)
        {
            _budgetRepository = budgetRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<List<BudgetAccount>> GetAvailableBudgetAccounts()
        {
            try
            {
                var accountEntities = await _budgetRepository.GetBudgetAccounts();

                var budgetAccounts = (from acc in accountEntities
                        select acc.ToModel()).ToList();

                foreach(var account in budgetAccounts )
                {
                    var departments = await _budgetRepository.GetBudgetAccountDepartments(account.Id);

                    account.Departments = (from department in departments
                                           select department.ToModel()).ToList();
                }


                return budgetAccounts;
            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Loading budget accounts failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(BudgetAccountService)
                });

                await Save(_httpContext);

                return new List<BudgetAccount>();
            }
        }


        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _budgetRepository.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
