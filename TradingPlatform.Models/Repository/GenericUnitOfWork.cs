using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DataAccess.Repository
{
    public class GenericUnitOfWork : IGenericUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext context;

        public GenericUnitOfWork(ApplicationDbContext context) { this.context = context; }

        public void SaveChanges() { context.SaveChanges(); }

        public async Task SaveAsync() { await context.SaveChangesAsync(); }

        public Dictionary<Type, object> repositories = new();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IGenericRepository<T>;

            IGenericRepository<T> repo = new EFGenericRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void Dispose() { context.Dispose(); }
    }
}
