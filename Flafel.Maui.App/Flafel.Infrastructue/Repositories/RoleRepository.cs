namespace Flafel.Infrastructure.Repositories
{
    public class RoleRepository<TContext> : BaseRepository<Role, TContext>, IRoleRepository where TContext : DbContext
    {
        public RoleRepository(TContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId, int pageIndex = 1, int pageSize = 20, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().Include(x => x.UserRoles.Where(u => u.SystemUserId.Value == userId))
                                            .ThenInclude(x=>x.UserRolePermissions)
                                       .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
