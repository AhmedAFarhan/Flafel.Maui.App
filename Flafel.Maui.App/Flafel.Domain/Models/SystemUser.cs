namespace Flafel.Domain.Models
{
    public class SystemUser 
    {
        private readonly List<UserRole> _userRoles = new();
        public IReadOnlyList<UserRole> UserRoles => _userRoles.AsReadOnly();

        public SystemUserId Id { get; set; } = default!;
        public CrewId? CrewId { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public bool IsDeleted { get; set; } = false;

        public static SystemUser Create(SystemUserId id, CrewId? crewId, string userName, string passwordHash)
        {
            //Domain model validation
            ArgumentException.ThrowIfNullOrWhiteSpace(userName);
            ArgumentException.ThrowIfNullOrEmpty(userName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(userName.Length, 30);
            ArgumentOutOfRangeException.ThrowIfLessThan(userName.Length, 3);

            ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);
            ArgumentException.ThrowIfNullOrEmpty(passwordHash);

            var user = new SystemUser
            {
                Id = id,
                CrewId = crewId,
                UserName = userName,
                PasswordHash = passwordHash,
            };

            return user;
        }
        public void Update(string userName, string passwordHash)
        {
            //Domain model validation
            ArgumentException.ThrowIfNullOrWhiteSpace(userName);
            ArgumentException.ThrowIfNullOrEmpty(userName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(userName.Length, 30);
            ArgumentOutOfRangeException.ThrowIfLessThan(userName.Length, 3);

            ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);
            ArgumentException.ThrowIfNullOrEmpty(passwordHash);

            UserName = userName;
            PasswordHash = passwordHash;
        }

        public UserRole AddUserRole(RoleId roleId)
        {
            var userRole = new UserRole(Id, roleId);
            _userRoles.Add(userRole);
            return userRole;
        }
        public void RemoveUserRole(RoleId roleId)
        {
            var userRole = _userRoles.FirstOrDefault(x => x.RoleId == roleId);
            if (userRole is not null)
            {
                _userRoles.Remove(userRole);
            }
        }
    }
}
