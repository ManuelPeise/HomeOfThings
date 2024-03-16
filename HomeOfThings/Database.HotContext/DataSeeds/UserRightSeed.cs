using Date.Models.Entities.User;
using Date.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.HotContext.DataSeeds
{
    internal class UserRightSeed : IEntityTypeConfiguration<UserRightEntity>
    {
        public void Configure(EntityTypeBuilder<UserRightEntity> builder)
        {
            builder.HasData(new List<UserRightEntity> {
                new UserRightEntity
                {
                    UserRightId = 1,
                    Name = AppModuleEnum.FamilyAdministration.ToString(),
                    ModuleKey = AppModuleEnum.FamilyAdministration,
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                },
                new UserRightEntity
                {
                    UserRightId = 2,
                    Name = AppModuleEnum.FamilyManagement.ToString(),
                    ModuleKey = AppModuleEnum.FamilyManagement,
                    CreatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    UpdatedAt = DateTime.UtcNow,
                }
            });
        }
    }
}
