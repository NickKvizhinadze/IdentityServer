using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CNP.Identity.Data;
using CNP.Identity.Models.Entities.Users;
using CNP.Identity.Models.AppSettings;

namespace CNP.Identity.Helpers.Extensions
{
    public static class IdentityServiceCollectionExtension
    {
        #region Methods
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            services.AddIdentity<CnpUser, IdentityRole>(config =>
            {
                config.Password = isDevelopment
                        ? appSettings.PasswordOptions.Development
                        : appSettings.PasswordOptions.Production;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddIdentityServer(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var miggrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var identityServerBuilder = services.AddIdentityServer()
                .AddAspNetIdentity<CnpUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder
                    .UseSqlServer(connectionString, opt => opt.MigrationsAssembly(miggrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder
                    .UseSqlServer(connectionString, opt => opt.MigrationsAssembly(miggrationAssembly));
                });

            if (isDevelopment)
                identityServerBuilder.AddDeveloperSigningCredential();
        }
        #endregion
    }
}
