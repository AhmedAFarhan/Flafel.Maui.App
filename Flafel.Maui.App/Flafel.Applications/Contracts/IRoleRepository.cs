
namespace Flafel.Applications.Contracts
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId, int pageIndex = 1, int pageSize = 20, CancellationToken cancellationToken = default);
    }
}
