using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Domain.Repository_interfaces
{
    public interface IRepositoryManager
    {
        IGenericRepository<ApplicationUser> Users { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Complaint> Complaints { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<ProductOrder> ProductOrders { get; }
    }
}
