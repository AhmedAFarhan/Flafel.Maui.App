namespace Flafel.Domain.Models
{
    public class StockItemUnit : Entity<StockItemUnitId>
    {
        internal StockItemUnit(StockItemId stockItemId, string name, double conversionFactorToBase, bool isBaseUnit, int priorityInConsumption)
        {
            Id = StockItemUnitId.Of(Guid.NewGuid());
            StockItemId = stockItemId;
            Name = name;
            ConversionFactorToBase = conversionFactorToBase;
            IsBaseUnit = isBaseUnit;
            PriorityInConsumption = priorityInConsumption;
        }

        public StockItemId StockItemId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public double ConversionFactorToBase { get; set; } // Factor to convert to a base unit like GRAM
        public bool IsBaseUnit { get; set; }
        public int PriorityInConsumption { get; set; } = 0;

    }
}
