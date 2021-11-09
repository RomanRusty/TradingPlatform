using System.Threading.Tasks;

namespace TradingPlatform.Domain.Repository_interfaces
{
    public interface IGenericUnitOfWork
    {
        void SaveChanges();
        Task SaveAsync();
        IGenericRepository<T> Repository<T>() where T : class;

    }
}
