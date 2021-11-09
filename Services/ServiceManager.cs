using AutoMapper;
using System;
using TradingPlatform.Domain.Repository_interfaces;
using TradingPlatform.Services.Abstractions;

namespace TradingPlatform.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<IComplaintService> _lazyComplaintService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<IProductOrderService> _lazyProductOrderService;
        private readonly Lazy<IProductService> _lazyProductService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _lazyComplaintService = new Lazy<IComplaintService>(() => new ComplaintService(repositoryManager, mapper));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper));
            _lazyProductOrderService = new Lazy<IProductOrderService>(() => new ProductOrderService(repositoryManager, mapper));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        }
        public ICategoryService CategoryService => _lazyCategoryService.Value;
        public IComplaintService ComplaintService => _lazyComplaintService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IProductOrderService ProductOrderService => _lazyProductOrderService.Value;
        public IProductService ProductService => _lazyProductService.Value;
    }
}