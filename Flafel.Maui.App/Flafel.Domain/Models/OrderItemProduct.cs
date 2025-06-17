namespace Flafel.Domain.Models
{
    public class OrderItemProduct : Entity<OrderItemProductId>
    {
        internal OrderItemProduct(OrderItemId orderItemId, ProductId productId, decimal price, int quantity)
        {
            Id = OrderItemProductId.Of(Guid.NewGuid());
            OrderItemId = orderItemId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public OrderItemId OrderItemId { get; private set; } = default!;
        public ProductId ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
