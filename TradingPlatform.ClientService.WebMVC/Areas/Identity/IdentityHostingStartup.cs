using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Persistence.Database;

[assembly: HostingStartup(typeof(TradingPlatform.ClientService.WebMVC.Areas.Identity.IdentityHostingStartup))]
namespace TradingPlatform.ClientService.WebMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}