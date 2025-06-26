namespace Flafel.Applications.Dtos.UserDtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Title { get; set; } = default!;
    }
}
