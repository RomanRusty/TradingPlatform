using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Persistence.Database;

namespace TradingPlatform.DatabaseService.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await ApplyMigrations(host.Services);
            await host.RunAsync();
        }
        private static async Task ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            await using RepositoryDbContext dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
            await dbContext.Database.MigrateAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseSerilog((context, loggerConfiguration)
                     => loggerConfiguration.ReadFrom.Configuration(context.Configuration)
                         .Enrich.WithEnvironment(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT"))
                         .Enrich.WithEnvironmentUserName()
                         .Enrich.WithEnvironmentName()
                         .Enrich.WithCorrelationId()
                         .Enrich.WithAssemblyName()
                         .Enrich.WithMemoryUsage()
                         .Enrich.FromLogContext()
                         .Enrich.WithProcessId()
                         .Enrich.WithThreadId()
                         //.WriteTo.File(new JsonFormatter(), "logs.json",
                         //    rollingInterval: RollingInterval.Day)
                         .WriteTo.Seq("http://localhost:5341/"))
                // alternative configuration from code 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
