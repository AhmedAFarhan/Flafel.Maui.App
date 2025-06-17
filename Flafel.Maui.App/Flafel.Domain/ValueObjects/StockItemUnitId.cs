using Flafel.Domain.Models;

namespace Flafel.Domain.ValueObjects
{
    public record StockItemUnitId
    {
        public Guid Value { get; }

        private StockItemUnitId(Guid value) => Value = value;

        public static StockItemUnitId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("StockItemUnitId can not be empty");
            }

            return new StockItemUnitId(value);
        }
    }
}
