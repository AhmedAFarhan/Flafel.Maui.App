namespace Flafel.Domain.Models
{
    public class CustomerAddress : Entity<CustomerAddressId>
    {
        public CustomerId CustomerId { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string? Region { get; set; } = default!;
        public string? HowToReach { get; set; }

        public static CustomerAddress Create(CustomerAddressId id, CustomerId customerId, string street, string? region, string? howToReach)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(street);
            ArgumentException.ThrowIfNullOrEmpty(street);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(street.Length, 150);

            if(region is not null)
            {
                ArgumentException.ThrowIfNullOrEmpty(region);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(region.Length, 150);
            }

            if(howToReach is not null)
            {
                ArgumentException.ThrowIfNullOrEmpty(howToReach);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(howToReach.Length, 250);
            }

            var customerAddress = new CustomerAddress
            {
                Id = id,
                CustomerId = customerId,
                Street = street,
                Region = region,
                HowToReach = howToReach,
            };

            return customerAddress;
        }
        public void Update(string street, string? region, string? howToReach)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(street);
            ArgumentException.ThrowIfNullOrEmpty(street);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(street.Length, 150);

            if (region is not null)
            {
                ArgumentException.ThrowIfNullOrEmpty(region);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(region.Length, 150);
            }

            if (howToReach is not null)
            {
                ArgumentException.ThrowIfNullOrEmpty(howToReach);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(howToReach.Length, 250);
            }

            Street = street;
            Region = region;
            HowToReach = howToReach;
        }
    }
}
