namespace Flafel.Domain.ValueObjects
{
    public record CustomerAddressId
    {
        public Guid Value { get; }

        private CustomerAddressId(Guid value) => Value = value;

        public static CustomerAddressId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CustomerAddressId can not be empty");
            }

            return new CustomerAddressId(value);
        }
    }
}
