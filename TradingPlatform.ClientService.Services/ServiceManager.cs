using ExampleWebApplication.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<IComplaintService> _lazyComplaintService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<IProductOrderService> _lazyProductOrderService;
        private readonly Lazy<IProductService> _lazyProductService;
        public ServiceManager(IOptions<AppConfiguration> config, HttpClient client)
        {
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(config, client));
            _lazyComplaintService = new Lazy<IComplaintService>(() => new ComplaintService(config, client));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(config, client));
            _lazyProductOrderService = new Lazy<IProductOrderService>(() => new ProductOrderService(config, client));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(config, client));
        }
        public ICategoryService CategoryService => _lazyCategoryService.Value;
        public IComplaintService ComplaintService => _lazyComplaintService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IProductOrderService ProductOrderService => _lazyProductOrderService.Value;
        public IProductService ProductService => _lazyProductService.Value;
    }
}