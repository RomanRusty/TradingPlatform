using System;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;

namespace TradingPlatform.DatabaseService.Persistence.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IGenericRepository<ApplicationUser>> _lazyUserService;
        private readonly Lazy<IGenericRepository<Category>> _lazyCategoryService;
        private readonly Lazy<IGenericRepository<Complaint>> _lazyComplaintService;
        private readonly Lazy<IGenericRepository<Order>> _lazyOrderService;
        private readonly Lazy<IGenericRepository<Product>> _lazyProductService;
        private readonly Lazy<IGenericRepository<ProductOrder>> _lazyProductOrderService;
        public RepositoryManager(IGenericUnitOfWork work)
        {
 
            _lazyUserService = new Lazy<IGenericRepository<ApplicationUser>>(work.Repository<ApplicationUser>());
            _lazyCategoryService = new Lazy<IGenericRepository<Category>>(work.Repository<Category>());
            _lazyComplaintService = new Lazy<IGenericRepository<Complaint>>(work.Repository<Complaint>());
            _lazyOrderService = new Lazy<IGenericRepository<Order>>(work.Repository<Order>());
            _lazyProductService = new Lazy<IGenericRepository<Product>>(work.Repository<Product>());
            _lazyProductOrderService = new Lazy<IGenericRepository<ProductOrder>>(work.Repository<ProductOrder>());
        }
        public IGenericRepository<ApplicationUser> Users => _lazyUserService.Value;
        public IGenericRepository<Category> Categories => _lazyCategoryService.Value;
        public IGenericRepository<Complaint> Complaints => _lazyComplaintService.Value;
        public IGenericRepository<Order> Orders => _lazyOrderService.Value;
        public IGenericRepository<Product> Products => _lazyProductService.Value;
        public IGenericRepository<ProductOrder> ProductOrders => _lazyProductOrderService.Value;

    }
}
