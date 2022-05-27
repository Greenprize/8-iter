using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server_v0._0.Models;

namespace Server_v0._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Clients/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Units}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{controller=Discounts}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{controller=Clients}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{controller=Sales}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{controller=OrderComponents}/{action=Index}/{id?}");
            });
        }
    }
}
