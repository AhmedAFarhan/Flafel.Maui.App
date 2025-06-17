namespace Flafel.Domain.ValueObjects
{
    public record InventoryTransactionId
    {
        public Guid Value { get; }

        private InventoryTransactionId(Guid value) => Value = value;

        public static InventoryTransactionId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("InventoryTransactionId can not be empty");
            }

            return new InventoryTransactionId(value);
        }
    }
}
