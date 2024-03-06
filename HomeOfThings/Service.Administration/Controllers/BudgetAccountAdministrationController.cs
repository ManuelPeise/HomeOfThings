using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Logic.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.Administration.Controllers
{
    public class BudgetAccountAdministrationController : ApiControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _databaseContext;


        public BudgetAccountAdministrationController(IBudgetRepository budgetRepository, IHttpContextAccessor httpContextAccessor, DatabaseContext context)
        {
            _budgetRepository = budgetRepository;
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = context;
        }

        [HttpGet(Name = "ImportBudgetAccouts")]
        public async Task ImportBudgetAccouts()
        {
            using (var service = new BudgetAccountAdministrationService(_budgetRepository, _httpContextAccessor, _databaseContext))
            {
                await service.ImportBudgetAccountingData();
            }
        }
    }
}
