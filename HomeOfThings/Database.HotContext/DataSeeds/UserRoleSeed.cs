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
                    Id = 1,
                    Name = "User",
                    RoleId = UserRoleEnum.User,
                    Description = "Default User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    Id = 2,
                    Name = "Admin",
                    RoleId = UserRoleEnum.Admin,
                    Description = "Admin User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    Id = 3,
                    Name = "SystemAdmin",
                    RoleId = UserRoleEnum.SystemAdmin,
                    Description = "System Admin User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                }
            });
        }
    }
}
