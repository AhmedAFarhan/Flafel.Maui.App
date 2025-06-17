namespace Flafel.Domain.Models
{
    public class ProductIngredient : Entity<ProductIngredientId>
    {
        internal ProductIngredient(ProductId productId, StockItemId stockItemId, StockItemUnitId stockItemUnitId, decimal quantity)
        {
            Id = ProductIngredientId.Of(Guid.NewGuid());
            ProductId = productId;
            StockItemId = stockItemId;
            StockItemUnitId = stockItemUnitId;
            Quantity = quantity;
        }

        public ProductId ProductId { get; private set; } = default!;
        public StockItemId StockItemId { get; private set; } = default!;
        public StockItemUnitId StockItemUnitId { get; private set; } = default!;
        public decimal Quantity { get; set; }
    }
}
