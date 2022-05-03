using Microsoft.AspNetCore.Hosting;

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