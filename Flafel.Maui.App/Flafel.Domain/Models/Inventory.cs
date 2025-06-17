namespace Flafel.Domain.Models
{
    public class Inventory : Entity<InventoryId>
    {
        public StockItemId StockItemId { get; set; } = default!;
        public StockItemUnitId StockItemUnitId { get; set; } = default!;
        public decimal Quantity { get; set; } = default!;

        public static Inventory Create(InventoryId id, StockItemId stockItemId, StockItemUnitId stockItemUnitId, decimal quantity)
        {
            //NOTE: QUANTITY COULD HAVE NEGATIVE VALUE, AND IN SHUCH USE CASE WE NEED TO ADJUST THE VALUE MANULALLY.

            var inventory = new Inventory
            {
                Id = id,
                StockItemId = stockItemId,
                StockItemUnitId = stockItemUnitId,
                Quantity = quantity
            };

            return inventory;
        }
        public void Update(StockItemUnitId stockItemUnitId, decimal quantity)
        {
            StockItemUnitId = stockItemUnitId;
            Quantity = quantity;
        }
    }
}
