namespace Flafel.Applications.Dtos.UserDtos
{
    public class UserRegesterRequestDto
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Guid? CrewId { get; set; } = default!;
        public IEnumerable<UserRoleDto> UserRoleDtos { get; set; } = default!;
    }
}
