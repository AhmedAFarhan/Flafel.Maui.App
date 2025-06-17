namespace Flafel.Domain.ValueObjects
{
    public record StockItemCategoryId
    {
        public Guid Value { get; }

        private StockItemCategoryId(Guid value) => Value = value;

        public static StockItemCategoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("StockItemCategoryId can not be empty");
            }

            return new StockItemCategoryId(value);
        }
    }
}
