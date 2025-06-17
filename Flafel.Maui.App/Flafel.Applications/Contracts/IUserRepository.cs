namespace Flafel.Applications.Contracts
{
    public interface IUserRepository : IBaseRepository<SystemUser>
    {
        Task<bool> IsUserExist(string username);
        Task<SystemUser?> GetUserByUsernameAsync(string username);
    }
}
