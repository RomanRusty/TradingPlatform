using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.ClientService.Persistence.HttpClients;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHomeService> _lazyHomeService;
        private readonly Lazy<IProductService> _lazyProductService;
        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<ICartService> _lazyCartService;
        public ServiceManager(IHttpClientManager httpClientManager, IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager)
        {
            _lazyHomeService = new Lazy<IHomeService>(() => new HomeService(httpClientManager, contextAccessor, userManager));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(httpClientManager, contextAccessor));
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(httpClientManager, contextAccessor));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(httpClientManager, contextAccessor, userManager));
            _lazyCartService = new Lazy<ICartService>(() => new CartService(httpClientManager, contextAccessor));
        }
        public IHomeService HomeService => _lazyHomeService.Value;
        public IProductService ProductService => _lazyProductService.Value;
        public ICategoryService CategoryService => _lazyCategoryService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public ICartService CartService => _lazyCartService.Value;
    }
}