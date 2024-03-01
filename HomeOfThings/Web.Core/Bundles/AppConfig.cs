using Database.HotContext;
using Microsoft.EntityFrameworkCore;

namespace Web.Core.Bundles
{
    internal static class AppConfig
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
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
    }
}
