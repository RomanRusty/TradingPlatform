using System.Threading.Tasks;

namespace TradingPlatform.DataAccess.Repository
{
    public interface IGenericUnitOfWork
    {
        void SaveChanges();
        Task SaveAsync();
        IGenericRepository<T> Repository<T>() where T : class;

    }
}
