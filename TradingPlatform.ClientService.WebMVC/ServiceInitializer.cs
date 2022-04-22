using Microsoft.Extensions.DependencyInjection;
using TradingPlatform.ClientService.Services;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.WebMVC
{
    public static class ServiceInitializer
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IComplaintService, ComplaintService>();
        }
    }
}
