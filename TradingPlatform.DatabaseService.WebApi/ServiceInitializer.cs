using Microsoft.Extensions.DependencyInjection;
using TradingPlatform.DatabaseService.Services;
using TradingPlatform.DatabaseService.Services.Abstractions;

namespace TradingPlatform.DatabaseService.WebApi
{
    public static class ServiceInitializer
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IComplaintService, ComplaintService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductOrderService, ProductOrderService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
