using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CNP.Identity.Helpers.Extensions;
using CNP.Identity.Models.AppSettings;
using CNP.Identity.Data;

namespace CNP.Identity
{
    public class Startup
    {
        #region Properties
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public Startup(IWebHostEnvironment environment, IConfiguration Configuration)
        {
            Environment = environment;
            this.Configuration = Configuration;
        }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            var isDevelopment = Environment.IsDevelopment();

            services.AddContext(Configuration);
            services.AddIdentity(Configuration, isDevelopment);
            services.AddIdentityServer(Configuration, isDevelopment);

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedData.EnsureSeedData(Configuration);
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
        #endregion
    }
}
