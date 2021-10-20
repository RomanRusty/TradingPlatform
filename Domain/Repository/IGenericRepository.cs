using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.Domain.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        Task AddAsync(TEntity item);
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity item);
        Task RemoveAsync(TEntity item);
        void Update(TEntity item);
        Task UpdateAsync(TEntity item);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        bool Exists(object id);
        bool Exists(TEntity item);
        Task<bool> ExistsAsync(object id);
        Task<bool> ExistsAsync(TEntity item);
        List<List<TEntity>> ToJaggedArray(IEnumerable<TEntity> array, int cols);
        
    }
}
