using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Flafel.Applications.Contracts.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int pageIndex = 1, int pageSize = 3, string? filterQuery = null, string? filterValue = null, Expression<Func<T, bool>>? baseFilter = null, Expression<Func<T, object>>[]? includes = null, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync<TId>(TId id, Expression<Func<T, object>>[] includes = null, CancellationToken cancellationToken = default);
        Task<T?> GetByPropertyAsync(Expression<Func<T, bool>> property, Expression<Func<T, object>>[] includes = null, CancellationToken cancellationToken = default);
		Task<T> AddOneAsync(T entity, Expression<Func<T, object>>[] includes = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<T?> UpdateAsync(Guid id, T entity, Expression<Func<T, object>>[] includes = null, CancellationToken cancellationToken = default);
        Task<T?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<long> GetCountAsync(string? filterQuery = null, string? filterValue = null, Expression<Func<T, bool>>? baseFilter = null, CancellationToken cancellationToken = default);
        void UpdateEntity(T entity);
    }
}
