using Data.Interfaces.Interfaces.Repositories.Finances;
using Database.HotContext;
using Date.Models.Entities.Log;
using Logic.Finances;
using Logic.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Administration
{
    public class BudgetAccountAdministrationService: ALogicBase, IDisposable
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly HttpContext _httpContext;
        private bool disposedValue;

        public BudgetAccountAdministrationService(IBudgetRepository budgetRepository, IHttpContextAccessor httpContextAccessor, DatabaseContext context) : base(context)
        {
            _budgetRepository = budgetRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task ImportBudgetAccountingData()
        {
            try
            {
                var databaseModified = false;

                var importer = new BudgetAccoutFileImporter();

                var accountingData = await importer.GetAccountingData();

                if (accountingData != null && accountingData.BudgetAccounts.Any())
                {
                    foreach (var account in accountingData.BudgetAccounts)
                    {
                        databaseModified = await _budgetRepository.ImportAccount(account);
                    }
                }

                if (databaseModified)
                {
                    await Save(_httpContext);
                }

            }
            catch (Exception exception)
            {
                await LogRepository.AddMessage(new LogEntity
                {
                    Message = "Importing budget accounting data failed!",
                    ExMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    TimeStamp = DateTime.UtcNow,
                    Trigger = nameof(BudgetAccountAdministrationService)
                });

                await Save(_httpContext);
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
