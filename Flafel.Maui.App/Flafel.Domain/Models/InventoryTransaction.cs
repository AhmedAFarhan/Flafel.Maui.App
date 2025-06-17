namespace Flafel.Domain.Models
{
    public class InventoryTransaction : Entity<InventoryTransactionId>
    {
        public StockItemId StockItemId { get; set; } = default!;
        public StockItemUnitId StockItemUnitId { get; set; } = default!;
        public decimal Quantity { get; set; } = default!;
        public InventoryTransactionType InventoryTransactionType{ get; set; }
        public string? Notes { get; set; }

        public static InventoryTransaction Create(InventoryTransactionId id, StockItemId stockItemId, StockItemUnitId stockItemUnitId, decimal quantity, InventoryTransactionType inventoryTransactionType, string? notes)
        {
            if (notes is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(notes);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(notes.Length, 250);
            }

            if (!Enum.IsDefined<InventoryTransactionType>(inventoryTransactionType))
            {
                throw new DomainException("InventoryTransactionType value is out of range");
            }

            var inventoryTransaction = new InventoryTransaction
            {
                Id = id,
                StockItemId = stockItemId,
                StockItemUnitId = stockItemUnitId,
                Quantity = quantity,
                InventoryTransactionType = inventoryTransactionType,
                Notes = notes
            };

            return inventoryTransaction;
        }
    }
}
