using Date.Models.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Ocsp;

namespace Database.HotContext.DataSeeds
{
    internal class BudgetDepartmentSeed : IEntityTypeConfiguration<BudgetDepartment>
    {
        public void Configure(EntityTypeBuilder<BudgetDepartment> builder)
        {
            builder.HasData(new List<BudgetDepartment>
            {
                new BudgetDepartment
                {
                    Id = 1,
                    ParentAccountId = 1,
                    Key = "labelFamilyActivities",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 2,
                    ParentAccountId = 2,
                    Key = "labelWorkShop",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 3,
                    ParentAccountId = 2,
                    Key = "labelRefuel",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 4,
                    ParentAccountId = 3,
                    Key = "labelTransfer",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 5,
                    ParentAccountId = 4,
                    Key = "labelTeleCommunication",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id= 6,
                    ParentAccountId= 5,
                    Key = "labelRestaurantVisit",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 7,
                    ParentAccountId = 6,
                    Key = "labelSalary",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 8,
                    ParentAccountId = 6,
                    Key = "labelOtherIncome",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 9,
                    ParentAccountId = 7,
                    Key = "labelReside",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 10,
                    ParentAccountId = 7,
                    Key = "labelEnergy",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 11,
                    ParentAccountId = 8,
                    Key = "labelGroceries",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 12,
                    ParentAccountId = 8,
                    Key = "labelTobacco",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 13,
                    ParentAccountId = 9,
                    Key = "labelAccommodation",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                },
                new BudgetDepartment
                {
                    Id = 14,
                    ParentAccountId = 9,
                    Key = "labelTouristTax"
                }
            });
        }
    }
}
