using Flafel.Applications.Contracts.Base;
using System.Linq.Expressions;
using Flafel.Infrastructure.Helpers;

namespace Flafel.Infrastructure.Repositories.Base
{
    public class BaseRepository<T, TContext>(TContext dbContext) : IBaseRepository<T> where T : class where TContext : DbContext
    {
        protected readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync(int pageIndex = 1, int pageSize = 20, string? filterQuery = null, string? filterValue = null, Expression<Func<T, bool>>? baseFilter = null, Expression<Func<T, object>>[]? includes = null)
        {
            var query = _dbSet.AsQueryable();

            // Apply base filter if provided
            if (baseFilter is not null)
            {
                query = query.Where(baseFilter);
            }

            //Includes
            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            //Filtering
            if (!string.IsNullOrWhiteSpace(filterValue))
            {
                var filterExpression = DynamicFilter.BuildDynamicFilter<T>(filterValue, string.IsNullOrWhiteSpace(filterQuery) ? "all" : filterQuery);
                query = query.Where(filterExpression);
            }

            //Paginations
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, Expression<Func<T, object>>[] includes = null)
        {
            var query = _dbSet.AsQueryable();

            //Includes
            if (includes is not null)
            {
                foreach (var include in includes)
                    query = query.Include(include);

                return await query.FirstOrDefaultAsync(i => EF.Property<Guid>(i, "Id") == id);
            }
            else
            {
                return await _dbSet.FindAsync(id);
            }
        }

        public async Task<T> AddOneAsync(T entity, Expression<Func<T, object>>[] includes = null)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public Task<T?> UpdateAsync(Guid id, T entity, Expression<Func<T, object>>[] includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is not null)
            {
                _dbSet.Remove(item);
            }
            return item;
        }

        public async Task<long> GetCountAsync(string? filterQuery = null, string? filterValue = null, Expression<Func<T, bool>>? baseFilter = null)
        {
            var query = _dbSet.AsQueryable();

            // Apply base filter if provided
            if (baseFilter is not null)
            {
                query = query.Where(baseFilter);
            }

            //Filtering
            if (!string.IsNullOrWhiteSpace(filterValue))
            {
                var filterExpression = DynamicFilter.BuildDynamicFilter<T>(filterValue, string.IsNullOrWhiteSpace(filterQuery) ? "all" : filterQuery);
                query = query.Where(filterExpression);
            }

            return await query.LongCountAsync();
        }

        public void UpdateEntity(T entity) => _dbSet.Update(entity);
    }
}
