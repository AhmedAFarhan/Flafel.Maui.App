namespace Flafel.Domain.ValueObjects
{
    public record OrderId
    {
        public Guid Value { get; }

        private OrderId(Guid value) => Value = value;

        public static OrderId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("OrderId can not be empty");
            }

            return new OrderId(value);
        }
    }
}
