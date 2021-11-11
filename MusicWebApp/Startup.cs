using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicWebApp.Areas.Identity.Data;

namespace MusicWebApp
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

            services.AddDatabaseDeveloperPageExceptionFilter();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "arearoute",
                    pattern: "{area:exists}/{controller}/{action}");
                endpoints.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            IdentityinitializerAsync(userManager, roleManager).Wait();
        }

        private async Task IdentityinitializerAsync(UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            List<string> roles = new() { "admin", "user" };
            foreach (var item in roles)
            {
                if (await roleManager.RoleExistsAsync(item) == false)
                {
                    IdentityRole role = new IdentityRole(item);
                    await roleManager.CreateAsync(role);
                }
            }
            AspNetUser user = await userManager.FindByNameAsync("root");
            if (user is null)
            {
                user = new AspNetUser()
                {
                    UserName = "root",
                    Email = "root@example.com",
                    Name = "root",
                    LastName = "root",
                    EmailConfirmed = true,


                };
                await userManager.CreateAsync(user, "root123");

            }
            if (await userManager.IsInRoleAsync(user, "admin") == false)
            {
                await userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
