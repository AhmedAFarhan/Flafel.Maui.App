namespace Flafel.Applications.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
        TRepository GetCustomRepository<TRepository>() where TRepository : class;
        Task SaveChangesAsync();
    }
}
