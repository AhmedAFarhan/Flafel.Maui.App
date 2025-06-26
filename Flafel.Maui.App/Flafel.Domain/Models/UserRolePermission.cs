namespace Flafel.Domain.Models
{
    public class UserRolePermission
    {
        internal UserRolePermission(UserRoleId userRoleId, RolePermission rolePermission)
        {
            Id = UserRolePermissionId.Of(Guid.NewGuid());
            UserRoleId = userRoleId;
            RolePermission = rolePermission;
        }
        public UserRolePermissionId Id { get; set; } = default!;
        public UserRoleId UserRoleId { get; set; } = default!;
        public RolePermission RolePermission { get; set; } = RolePermission.READ;
    }
}
