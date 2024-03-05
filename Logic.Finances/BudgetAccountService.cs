using Data.Interfaces.Interfaces.Repositories.Finances;

namespace Logic.Finances
{
    public class BudgetAccountService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetAccountService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
    }
}
