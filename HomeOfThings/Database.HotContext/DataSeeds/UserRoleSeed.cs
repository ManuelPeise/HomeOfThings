using Date.Models.Entities.User;
using Date.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.HotContext.DataSeeds
{
    public class UserRoleSeed : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasData(new List<UserRoleEntity>
            {
                new UserRoleEntity
                {
                    UserRoleId = 1,
                    Name = "User",
                    RoleKey = UserRoleEnum.User,
                    Description = "Default User",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    UserRoleId = 2,
                    Name = "Admin",
                    RoleKey = UserRoleEnum.Admin,
                    Description = "Admin User",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    UserRoleId = 3,
                    Name = "SystemAdmin",
                    RoleKey = UserRoleEnum.SystemAdmin,
                    Description = "System Admin User",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = "System",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                }
            });
        }
    }
}
