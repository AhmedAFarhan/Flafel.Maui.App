namespace Flafel.Domain.Models
{
    public class StockItem : Aggregate<StockItemId>
    {
        private readonly List<StockItemUnit> _stockItemUnits = new();
        public IReadOnlyList<StockItemUnit> StockItemUnits => _stockItemUnits.AsReadOnly();

        public StockItemCategoryId StockItemCategoryId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Image { get; set; } = default!;

        public static StockItem Create(StockItemId id, StockItemCategoryId stockItemCategoryId, string name, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            var stockItem = new StockItem
            {
                Id = id,
                Name = name,
                Image = image,
            };

            return stockItem;
        }
        public void Update(StockItemCategoryId stockItemCategoryId, string name, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            Name = name;
            Image = image;
        }

        public void AddStockItemUnit(string name, double conversionFactorToBase, bool isBaseUnit, int priorityInConsumption)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(conversionFactorToBase);

            ArgumentOutOfRangeException.ThrowIfNegative(priorityInConsumption);

            var stockItemUnit = new StockItemUnit(Id, name, conversionFactorToBase, isBaseUnit, priorityInConsumption);
            _stockItemUnits.Add(stockItemUnit);
        }
        public void UpdateStockItemUnit(string name, double conversionFactorToBase, bool isBaseUnit, int priorityInConsumption)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(conversionFactorToBase);

            ArgumentOutOfRangeException.ThrowIfNegative(priorityInConsumption);

            var stockItemUnit = _stockItemUnits.FirstOrDefault(x => x.Name == name);
            if (stockItemUnit is not null)
            {
                stockItemUnit.Name = name;
                stockItemUnit.ConversionFactorToBase = conversionFactorToBase;
                stockItemUnit.IsBaseUnit = isBaseUnit;
                stockItemUnit.PriorityInConsumption = priorityInConsumption;
            }
        }
        public void RemoveStockItemUnit(string name)
        {
            var stockItemUnit = _stockItemUnits.FirstOrDefault(x => x.Name == name);
            if (stockItemUnit is not null)
            {
                _stockItemUnits.Remove(stockItemUnit);
            }
        }
    }
}
