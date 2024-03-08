using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Date.Models.Models.Finance;
using Logic.Finances;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.Finance
{
    public class BudgetAccountingController: ApiControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _databaseContext;
        public BudgetAccountingController(IBudgetRepository budgetRepository, IHttpContextAccessor httpContextAccessor, DatabaseContext databaseContext)
        {
            _budgetRepository = budgetRepository;
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = databaseContext;
        }

        [HttpGet(Name = "LoadBudgetAccounts")]
        public async Task<List<BudgetAccount>> LoadBudgetAccounts()
        {
            using (var service = new BudgetAccountService(_budgetRepository, _httpContextAccessor, _databaseContext))
            {
                return await service.GetAvailableBudgetAccounts();
            }
        }

        [HttpPost(Name = "ImportAccountDepartment")]
        public async Task<bool> ImportAccountDepartment([FromBody] BudgetAccountDepartment accountDepartment)
        {
            using (var service = new BudgetAccountService(_budgetRepository, _httpContextAccessor, _databaseContext))
            {
                return await service.ImportAccountDepartment(accountDepartment);
            }
        }

    }
}
