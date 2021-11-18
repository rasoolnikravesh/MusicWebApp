using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicWebApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MusicWebApp.Areas.Identity.IdentityHostingStartup))]
namespace MusicWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MusicAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MusicWebAppIdentityDbContextConnection")));

                services.AddDefaultIdentity<AspNetUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MusicAppContext>()
                    .AddDefaultTokenProviders();

                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;

                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);


                });
                services.AddAuthorization(x =>
                {
                    x.AddPolicy("MusicPolicy", y => y.RequireRole("superadmin"));

                });
                services.ConfigureApplicationCookie(x =>
                {
                    x.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = y =>
                        {

                            y.Response.Redirect("/account/loginregister");
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = z =>
                        {   
                            z.Response.Redirect("/account/loginregister");
                            return Task.CompletedTask;
                        }


                    };
                });
            });
        }
    }
}