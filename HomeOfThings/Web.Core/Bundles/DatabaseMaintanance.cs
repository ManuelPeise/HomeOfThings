using Database.HotContext;
using Date.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Web.Core.Bundles
{
    public static class DatabaseMaintanance
    {
        public static void MigrateDatabase(IServiceCollection services)
        {
            var databaseContextService = GetDatabeseService(services);

            var pendingMigrations = databaseContextService.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                databaseContextService.Database.Migrate();
            }
        }

        public static void SeedUserData(IServiceCollection services, IConfiguration config)
        {
            var databaseContextService = GetDatabeseService(services);

            var salt = Guid.NewGuid().ToString();

            if (databaseContextService.UserTable.FirstOrDefault(x => x.UserId == 1) == null)
            {
                try
                {
                    var userEntity = new UserEntity
                    {
                        UserId = 1,
                        Email = config["defaultUser:email"],
                        Password = GetEncodedPassword(config["defaultUser:password"], salt),
                        Salt = salt,
                        IsActive = Convert.ToBoolean(config["defaultUser:isActive"] ?? "true"),
                        CreatedBy = "System",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedBy = "System",
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var userRoleEntity = new UserRolesEntity
                    {
                        UserRolesId = 1,
                        UserId = 1,
                        UserRoleId = 3,
                        CreatedBy = "System",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedBy = "System",
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var userAccessRightEntity = new UserAccessRightEntity
                    {
                        UserAccessRightId = 1,
                        UserRightId = 1,
                        UserId = 1,
                        Deny = false,
                        Delete = true,
                        View = true,
                        Write = true,
                        CreatedBy = "System",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedBy = "System",
                        UpdatedAt = DateTime.UtcNow,
                    };

                    databaseContextService.UserTable.Add(userEntity);
                    databaseContextService.UserAccessRightsTable.Add(userAccessRightEntity);
                    databaseContextService.UserRolesTable.Add(userRoleEntity);

                    databaseContextService.SaveChanges();
                }catch(Exception ex)
                {
                    var mes = ex.Message;
                }
            }

        }

        private static DatabaseContext GetDatabeseService(IServiceCollection services)
        {
           
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetRequiredService<DatabaseContext>();
        }

        private static string GetEncodedPassword(string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password).ToList();

            bytes.AddRange(Encoding.ASCII.GetBytes(salt));

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
