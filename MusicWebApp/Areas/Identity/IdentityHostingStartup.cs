using System;
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
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MusicAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MusicWebAppIdentityDbContextConnection")));
                
                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MusicAppContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}