using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Reflection;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Persistence.Database;
using TradingPlatform.DatabaseService.Persistence.Middleware;
using TradingPlatform.DatabaseService.Persistence.Profiles;
using TradingPlatform.DatabaseService.Persistence.Repository;
using TradingPlatform.DatabaseService.Presentation;
using TradingPlatform.DatabaseService.Services;
using TradingPlatform.DatabaseService.Services.Abstractions;

namespace TradingPlatform.DatabaseService.Api
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

            services.AddDbContext<RepositoryDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));


            services.AddAutoMapper(typeof(CategoriesProfile).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatabaseMicroservice", Version = "v1" });
            });
            services.AddScoped(typeof(IGenericUnitOfWork), typeof(GenericUnitOfWork));
            services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddControllers().AddApplicationPart(typeof(CategoriesApiController).Assembly);

    

            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatabaseMicroservice"));
                serviceProvider.Seed();
            }
            app.UseExceptionHandler(error => error.Run(async context =>
            {
                var feature =
                    context.Features
                        .Get<IExceptionHandlerPathFeature>(); //here you can get the actual exception 'feature.Error'

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                { Error = "Ups... Something went wrong" }));
            }));

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}