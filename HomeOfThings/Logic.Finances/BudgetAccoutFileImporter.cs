using Data.Ressources;
using Date.Models.Models.Finance;
using Logic.Shared;

namespace Logic.Finances
{
    public class BudgetAccoutFileImporter: AResourceFileLoader
    {
        public async Task<BudgetAccountingData?> GetAccountingData()
        {
            var model =  await GetModelFromResourceFile<BudgetAccountingData>(RessourceNames.BudgetAccountTemplate);

            if(model != null)
            {
                return model;
            }

            return null;
        }
    }
}
