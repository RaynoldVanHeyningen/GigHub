using System;
using GigHub.Areas.Identity.Data;
using GigHub.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GigHub.Areas.Identity.IdentityHostingStartup))]
namespace GigHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<GigHubIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("GigHubIdentityDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<GigHubIdentityDbContext>();
            });
        }
    }
}