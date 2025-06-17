namespace Flafel.Domain.ValueObjects
{
    public record DeliveryAddress
    {
        public string Street { get; set; } = default!;
        public string? Region { get; set; } = default!;
        public string? HowToReach { get; set; }

        protected DeliveryAddress()
        {

        }

        private DeliveryAddress(string street, string? region, string? howToReach)
        {
            Street = street;
            Region = region;
            HowToReach = howToReach;
        }

        public static DeliveryAddress Of(string street, string? region, string? howToReach)
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

            return new DeliveryAddress(street, region, howToReach);
        }
    }
}
