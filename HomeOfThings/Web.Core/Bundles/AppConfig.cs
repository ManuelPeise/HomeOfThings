using Data.Interfaces.Interfaces.Clients;
using Database.HotContext;
using Logic.Shared.Clients;
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
            
        }

        internal static void ConfigureClients(IServiceCollection services)
        {
            services.AddScoped<IEmailClient, EmailClient>();
        }

        internal static void ConfigureCors(IServiceCollection services, string policy)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(policy, opt =>
                {
                    opt.AllowAnyHeader();
                    opt.AllowAnyMethod();
                    opt.AllowAnyOrigin();
                });
            });
        }
    }
}
