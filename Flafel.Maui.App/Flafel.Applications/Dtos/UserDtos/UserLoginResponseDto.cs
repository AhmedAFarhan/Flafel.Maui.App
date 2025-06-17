namespace Flafel.Applications.Dtos.UserDtos
{
    public class UserLoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string? FullName { get; set; }
        public IEnumerable<UserRoleDto> UserRolesDtos { get; set; } = default!;
    }
}
