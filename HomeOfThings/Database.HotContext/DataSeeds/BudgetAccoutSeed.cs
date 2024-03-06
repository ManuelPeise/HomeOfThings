using Date.Models.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.HotContext.DataSeeds
{
    public class BudgetAccoutSeed : IEntityTypeConfiguration<BudgetAccount>
    {
        public void Configure(EntityTypeBuilder<BudgetAccount> builder)
        {
            builder.HasData(new List<BudgetAccount>
            {
                new BudgetAccount
                {
                    Id = 1,
                    Key = "labelActivities",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 2,
                    Key = "labelCar",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 3,
                    Key = "labelCarryOfLastMonth",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 4,
                    Key = "labelCommunication",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 5,
                    Key = "labelGastronomy",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 6,
                    Key = "labelIncome",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 7,
                    Key = "labelReside",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 8,
                    Key = "labelShopping",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetAccount
                {
                    Id = 9,
                    Key = "labelVacation",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },

            });
        }
    }
}
