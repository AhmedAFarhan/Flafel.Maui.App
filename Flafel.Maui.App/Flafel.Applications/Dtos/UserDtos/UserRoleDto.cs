namespace Flafel.Applications.Dtos.UserDtos
{
    public class UserRoleDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Role { get; set; } = default!;
        public IEnumerable<UserPermissionDto> UserPermissionsDto { get; set; } = default!;
    }
}
