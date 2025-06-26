namespace Flafel.Applications.Dtos.UserDtos
{
    public class UserRoleResponseDto
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = default!;
        public bool IsActive { get; set; }
        public IEnumerable<UserPermissionDto> UserPermissionDtos { get; set; } = default!;
    }
}
