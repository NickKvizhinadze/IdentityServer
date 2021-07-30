using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CNP.Identity.Data;

namespace CNP.Identity.Helpers.Extensions
{
    public static class DbContextServiceExtension
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var miggrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(miggrationAssembly)));
        }
    }
}
