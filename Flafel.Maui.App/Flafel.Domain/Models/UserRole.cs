namespace Flafel.Domain.Models
{
    public class UserRole
    {
        private readonly List<UserRolePermission> _userRolePermissions = new();
        public IReadOnlyList<UserRolePermission> UserRolePermissions => _userRolePermissions.AsReadOnly();

        internal UserRole(SystemUserId systemUserId, RoleId roleId)
        {
            Id = UserRoleId.Of(Guid.NewGuid());
            SystemUserId = systemUserId;
            RoleId = roleId;
        }

        public UserRoleId Id { get; set; } = default!;
        public SystemUserId SystemUserId { get; set; } = default!;
        public RoleId RoleId { get; set; } = default!;

        public Role Role { get; set; } = default!;

        public void AddPermission(RolePermission rolePermission)
        {
            if (!Enum.IsDefined<RolePermission>(rolePermission))
            {
                throw new DomainException("RolePermission value is out of range");
            }

            var userRolePermission = new UserRolePermission(Id, rolePermission);

            _userRolePermissions.Add(userRolePermission);
        }
        public void RemovePermission(RolePermission rolePermission)
        {
            if (!Enum.IsDefined<RolePermission>(rolePermission))
            {
                throw new DomainException("RolePermission value is out of range");
            }

            var userRolePermission = _userRolePermissions.FirstOrDefault(x => x.RolePermission == rolePermission);

            if (userRolePermission is not null)
            {
                _userRolePermissions.Remove(userRolePermission);
            }
        }
    }
}
