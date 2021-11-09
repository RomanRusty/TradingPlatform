using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Domain.Repository_interfaces;
using TradingPlatform.Persistence.Database;
using TradingPlatform.Persistence.Middleware;
using TradingPlatform.Persistence.Profiles;
using TradingPlatform.Persistence.Repository;
using TradingPlatform.Services;
using TradingPlatform.Services.Abstractions;

namespace Web
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
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
            services.AddDbContext<RepositoryDbContext>(options =>
               options.UseLazyLoadingProxies().UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web1", Version = "v1" });
            });

            services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
            services.AddScoped(typeof(IGenericUnitOfWork), typeof(GenericUnitOfWork));
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<RepositoryDbContext>().AddDefaultTokenProviders();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationUsersProfile());
                mc.AddProfile(new CategoriesProfile());
                mc.AddProfile(new ComplaintsProfile());
                mc.AddProfile(new OrdersProfile());
                mc.AddProfile(new ProductImagesProfile());
                mc.AddProfile(new ProductImageThumbnailsProfile());
                mc.AddProfile(new ProductOrdersProfile());
                mc.AddProfile(new ProductsProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddControllers()
                .AddApplicationPart(typeof(TradingPlatform.Presentation.CategoriesApiController).Assembly)
                .AddApplicationPart(typeof(TradingPlatform.Presentation.ComplaintsApiController).Assembly)
                .AddApplicationPart(typeof(TradingPlatform.Presentation.OrdersApiController).Assembly)
                .AddApplicationPart(typeof(TradingPlatform.Presentation.ProductOrdersApiController).Assembly)
                .AddApplicationPart(typeof(TradingPlatform.Presentation.ProductsApiController).Assembly)
                ;
            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
                serviceProvider.Seed();
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
