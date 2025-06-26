namespace Flafel.Domain.Models
{
    public class Role
    {
        public RoleId Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<UserRole> UserRoles { get; set; } = default!;

        public static Role Create(RoleId id, string name)
        {
            //Domain model validation
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            var role = new Role
            {
                Id = id,
                Name = name,
            };

            return role;
        }
    }
}
