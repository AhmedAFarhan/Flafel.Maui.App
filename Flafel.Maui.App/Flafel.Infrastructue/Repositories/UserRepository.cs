namespace Flafel.Infrastructure.Repositories
{
    public class UserRepository<TContext> : BaseRepository<SystemUser, TContext>, IUserRepository where TContext : DbContext
    {
        public UserRepository(TContext dbContext) : base(dbContext) { }

        public async Task<SystemUser?> GetUserByUsernameAsync(string username)
        {
            return await _dbSet.AsNoTracking().Include(x => x.UserRoles)
                                    .ThenInclude(x => x.Role)
                               .Include(x => x.UserRoles)
                                    .ThenInclude(x => x.UserRolePermissions)
                               .FirstOrDefaultAsync(u => u.UserName == username);

        }

        public async Task<bool> IsUserExist(string username)
        {
            return await _dbSet.AnyAsync(u => u.UserName == username);
        }
    }
}
