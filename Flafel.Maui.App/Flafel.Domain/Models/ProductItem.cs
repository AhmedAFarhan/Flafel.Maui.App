namespace Flafel.Domain.Models
{
    public class ProductItem : Entity<ProductItemId>
    {
        internal ProductItem(ProductId parentProductId, ProductId childProductId, int quantity)
        {
            Id = ProductItemId.Of(Guid.NewGuid());
            ParentProductId = parentProductId;
            ChildProductId = childProductId;
            Quantity = quantity;
        }

        public ProductId ParentProductId { get; private set; } = default!;
        public ProductId ChildProductId { get; private set; } = default!;
        public int Quantity { get; private set; } = default!;
    }
}
