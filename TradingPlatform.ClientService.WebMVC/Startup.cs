using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.ClientService.Persistence.Database;
using TradingPlatform.ClientService.Persistence.HttpClients;
using TradingPlatform.ClientService.Persistence.Middleware;
using TradingPlatform.ClientService.Presentation;
using TradingPlatform.ClientService.Services;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.WebMVC
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            services.AddControllersWithViews().AddApplicationPart(typeof(HomeController).Assembly);
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
                //etc
            });

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];

                    //options.SaveTokens = true;
                    //options.Events.OnCreatingTicket = ctx =>
                    //{
                    //    List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();

                    //    tokens.Add(new AuthenticationToken()
                    //    {
                    //        Name = "TicketCreated",
                    //        Value = DateTime.UtcNow.ToString()
                    //    });

                    //    ctx.Properties.StoreTokens(tokens);

                    //    return Task.CompletedTask;
                    //};
                });


            services.Configure<AppConfiguration>(Configuration);
            services.AddHttpClient<IHttpClientManager, HttpClientManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMigrationsEndPoint();
            app.UseHsts();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
