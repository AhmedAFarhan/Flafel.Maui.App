namespace Flafel.Domain.ValueObjects
{
    public record StockItemId
    {
        public Guid Value { get; }

        private StockItemId(Guid value) => Value = value;

        public static StockItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("StockItemId can not be empty");
            }

            return new StockItemId(value);
        }
    }
}
