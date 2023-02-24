using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Services;

namespace WebAppSalesMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Start edit
            services.AddDbContext<WebAppSalesMVCContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("WebAppSalesMVCContext"), builder => builder.MigrationsAssembly("WebAppSalesMVC")));
            services.AddScoped<SubsidiaryService>();
            services.AddScoped<StateService>();
            services.AddScoped<SalesRecordService>();
            // End edit
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Start edit
            var usEs = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(usEs),
                SupportedCultures = new List<CultureInfo> { usEs },
                SupportedUICultures = new List<CultureInfo> { usEs }
            };
            // End edit
            app.UseRequestLocalization(localizationOptions);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}