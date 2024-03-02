using Data.Interfaces.Interfaces.Repositories.Administration;
using Data.Interfaces.Interfaces.Repositories.User;
using Data.Interfaces.UnitsOfWork;
using Database.HotContext;
using Logic.Administration;
using Logic.Shared.Repositories;
using Logic.Shared.UnitsOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Web.Core.Bundles
{
    internal static class AppConfig
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        internal static void ConfigureDatabaseService(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                var connection = config.GetConnectionString("HotDataContext") ?? null;

                if (connection == null)
                {
                    throw new InvalidOperationException("No database connection found!");
                }

                opt.UseMySQL(connection);

            });
        }

        internal static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserAdministrationRepository, UserAdministartionRepository>();
            services.AddScoped<IUserAdministrationService, UserAdministrationService>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        }
    }
}
