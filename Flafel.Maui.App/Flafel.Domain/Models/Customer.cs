namespace Flafel.Domain.Models
{
    public class Customer : Entity<CustomerId>
    {
        public string FullName { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public int Points { get; set; } = 0;

        public static Customer Create(CustomerId id, string fullName, string mobile, int points)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
            ArgumentException.ThrowIfNullOrEmpty(fullName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(fullName.Length, 150);

            ArgumentException.ThrowIfNullOrWhiteSpace(mobile);
            ArgumentException.ThrowIfNullOrEmpty(mobile);
            ArgumentOutOfRangeException.ThrowIfNotEqual(mobile.Length, 11);

            ArgumentOutOfRangeException.ThrowIfNegative(points);

            var customer = new Customer
            {
                Id = id,
                FullName = fullName,
                Mobile = mobile,
                Points = points,
            };

            return customer;
        }
        public void Update(string fullName, string mobile, int points)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
            ArgumentException.ThrowIfNullOrEmpty(fullName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(fullName.Length, 150);

            ArgumentException.ThrowIfNullOrWhiteSpace(mobile);
            ArgumentException.ThrowIfNullOrEmpty(mobile);
            ArgumentOutOfRangeException.ThrowIfNotEqual(mobile.Length, 11);

            ArgumentOutOfRangeException.ThrowIfNegative(points);

            FullName = fullName;
            Mobile = mobile;
            Points = points;
        }
    }
}
