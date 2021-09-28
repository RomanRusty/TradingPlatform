using System.Threading.Tasks;

namespace TradingPlatform.Data
{
    public interface IGenericUnitOfWork
    {
        void SaveChanges();
        Task SaveAsync();
        IGenericRepository<T> Repository<T>() where T : class;

    }
}
