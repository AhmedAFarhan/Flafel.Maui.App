namespace Flafel.Domain.ValueObjects
{
    public record InventoryId
    {
        public Guid Value { get; }

        private InventoryId(Guid value) => Value = value;

        public static InventoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("InventoryId can not be empty");
            }

            return new InventoryId(value);
        }
    }
}
