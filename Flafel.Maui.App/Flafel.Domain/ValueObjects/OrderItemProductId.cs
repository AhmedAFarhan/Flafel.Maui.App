namespace Flafel.Domain.ValueObjects
{
    public record OrderItemProductId
    {
        public Guid Value { get; }

        private OrderItemProductId(Guid value) => Value = value;

        public static OrderItemProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("OrderItemProductId can not be empty");
            }

            return new OrderItemProductId(value);
        }
    }
}
