using Date.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Database.HotContext.DataSeeds
{
    public class UserSeed : IEntityTypeConfiguration<UserEntity>
    {
        private readonly IConfiguration _config;

        public UserSeed(IConfiguration config)
        {
            _config = config;
        }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            var salt = Guid.NewGuid().ToString();

            builder.HasData(new UserEntity
            {
                Id = 1,
                Email = _config["defaultUser:email"],
                Password = GetEncodedPassword(_config["defaultUser:password"], salt),
                Salt = salt,
                IsActive = Convert.ToBoolean(_config["defaultUser:isActive"] ?? "true"),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                UserRolesJson = JsonConvert.SerializeObject(new UserRoleEntity
                {
                    Id = 3,
                    Name = "System Admin",
                    Description = "System Admin User",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                })
            });
        }

        private string GetEncodedPassword(string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password).ToList();

            bytes.AddRange(Encoding.ASCII.GetBytes(salt));

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
