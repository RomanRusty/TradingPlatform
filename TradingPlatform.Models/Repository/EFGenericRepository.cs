using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace TradingPlatform.DataAccess.Repository
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ApplicationDbContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        { 
            return _dbSet.ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        { 
            return await _dbSet.ToListAsync(); 
        }
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            
            return _dbSet.Where(predicate).ToList(); 
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        { 
            return await _dbSet.Where(predicate).ToListAsync(); 
        }
        public TEntity FindById(object id)
        { 
            return _dbSet.Find(id); 
        }
        public async Task<TEntity> FindByIdAsync(object id)
        { 
            return await _dbSet.FindAsync(id);
        }
        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public async Task AddAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public async Task RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        { 
            return Include(includeProperties).ToList(); 
        }
        public async Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties) 
        { 
            return await Include(includeProperties).ToListAsync(); 
        }
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        public bool Exists(object id)
        {
           return FindById(id)!= null;
        }
        public bool Exists(TEntity item)
        {
            return _context.Find<TEntity>(item) != null;
        }
        public async Task<bool> ExistsAsync(object id)
        {
            return await FindByIdAsync(id) != null;
        }
        public async Task<bool> ExistsAsync(TEntity item)
        {
            return await _context.FindAsync<TEntity>(item) != null;
        }
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public List<List<TEntity>> ToJaggedArray(IEnumerable<TEntity> array, int cols)
        {
            int index = 0;
            List<List<TEntity>> jaggedArray = new();
            for (int i = 0; i <Math.Ceiling((double)array.Count()/cols); i++)
            {
                List<TEntity> rows = new();
                for (int j = 0; j < cols; j++)
                {
                    if (index >= array.Count())
                        break;
                    rows.Add(array.ElementAt(index++));
                }
                jaggedArray.Add(rows);
            }
            return jaggedArray;
        }
    }
}