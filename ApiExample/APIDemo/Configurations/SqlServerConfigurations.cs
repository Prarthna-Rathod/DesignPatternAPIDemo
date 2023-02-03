using DemoApplication.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Configurations
{
    public static class SqlServerConfigurations
    {
        public static void AddSqlServer(this IServiceCollection services,IConfiguration configuration)
        {
            var connString = configuration["ConnectionStrings:conn"];

            services.AddDbContext<StudResultDBContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(connString, x =>
                {
                    x.MigrationsAssembly("DemoApplication.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);
        }
    }
}
