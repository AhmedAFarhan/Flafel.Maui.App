using Flafel.Applications.Contracts.Base;
using Flafel.Applications.UnitOfWork;
using Flafel.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Flafel.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext>(TContext dbContext, IServiceProvider serviceProvider) : IUnitOfWork where TContext : DbContext
    {
        private readonly Dictionary<Type, object> _repositories = new();

        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new BaseRepository<T, TContext>(dbContext);
                _repositories[typeof(T)] = repository;
            }

            return (IBaseRepository<T>)_repositories[typeof(T)];
        }

        public TRepository GetCustomRepository<TRepository>() where TRepository : class
        {
            return serviceProvider.GetRequiredService<TRepository>();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
