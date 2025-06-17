namespace Flafel.Domain.Models
{
    public class CrewTitle : Entity<CrewTitleId>
    {
        public string Name { get; set; } = default!;
        public static CrewTitle Create(CrewTitleId id, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            var crewTitle = new CrewTitle
            {
                Id = id,
                Name = name,
            };

            return crewTitle;
        }
        public void Update(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            Name = name;
        }
    }
}
