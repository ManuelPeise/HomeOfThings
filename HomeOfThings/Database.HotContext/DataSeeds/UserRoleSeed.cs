using Date.Models.Entities.User;
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
                    Description = "Default User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    Id = 2,
                    Name = "Admin",
                    Description = "Admin User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                },
                new UserRoleEntity
                {
                    Id = 3,
                    Name = "System Admin",
                    Description = "System Admin User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                }
            });
        }
    }
}
