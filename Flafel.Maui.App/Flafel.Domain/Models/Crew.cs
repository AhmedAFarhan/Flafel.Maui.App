namespace Flafel.Domain.Models
{
    public class Crew : Entity<CrewId>
    {
        public string Name { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public SalaryType SalaryType { get; set; }
        public CrewTitleId CrewTitleId { get; set; } = default!;

        public static Crew Create(CrewId id, string name, string mobile, SalaryType salaryType, CrewTitleId crewTitleId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentException.ThrowIfNullOrWhiteSpace(mobile);
            ArgumentException.ThrowIfNullOrEmpty(mobile);
            ArgumentOutOfRangeException.ThrowIfNotEqual(mobile.Length, 11);

            if (!Enum.IsDefined<SalaryType>(salaryType))
            {
                throw new DomainException("SalaryType value is out of range");
            }

            var crew = new Crew
            {
                Id = id,
                Name = name,
                Mobile = mobile,
                SalaryType = salaryType,
                CrewTitleId = crewTitleId,
            };

            return crew;
        }
        public void Update(string name, string mobile, SalaryType salaryType, CrewTitleId crewTitleId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentException.ThrowIfNullOrWhiteSpace(mobile);
            ArgumentException.ThrowIfNullOrEmpty(mobile);
            ArgumentOutOfRangeException.ThrowIfNotEqual(mobile.Length, 11);

            if (!Enum.IsDefined<SalaryType>(salaryType))
            {
                throw new DomainException("SalaryType value is out of range");
            }

            Name = name;
            Mobile = mobile;
            SalaryType = salaryType;
            CrewTitleId = crewTitleId;
        }
    }
}
