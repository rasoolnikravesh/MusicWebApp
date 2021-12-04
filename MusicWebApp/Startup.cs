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
using AutoMapper;
using MusicWebApp.Mapers;
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            var mapperconfig = new MapperConfiguration(x => x.AddProfile(new MuiscAppMaperProfile()));
            IMapper mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);

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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                     name: "MyAreaSystemAdmin",
                     areaName: "Admin",
                     pattern: "Panel/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
            IdentityinitializerAsync(userManager, roleManager).Wait();
        }

        private async Task IdentityinitializerAsync(UserManager<AspNetUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            List<string> roles = new() { "superadmin", "admin", "editor", "user" };
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
            if (await userManager.IsInRoleAsync(user, "superadmin") == false)
            {
                await userManager.AddToRoleAsync(user, "superadmin");
            }
        }
    }
}
