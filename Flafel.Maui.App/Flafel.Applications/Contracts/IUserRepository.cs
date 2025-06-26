namespace Flafel.Applications.Contracts
{
    public interface IUserRepository : IBaseRepository<SystemUser>
    {
        Task<bool> IsUserExist(string username, CancellationToken cancellationToken = default);
        Task<SystemUser?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    }
}
