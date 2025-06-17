namespace Flafel.Domain.Models
{
    public class OrderItem : Aggregate<OrderItemId>
    {
        private readonly List<OrderItemProduct> _orderItemProducts = new();
        public IReadOnlyList<OrderItemProduct> OrderItemProducts => _orderItemProducts.AsReadOnly();

        internal OrderItem(OrderId orderId, ProductId productId, decimal price, int quantity)
        {
            Id = OrderItemId.Of(Guid.NewGuid());
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public OrderId OrderId { get; private set; } = default!;
        public ProductId ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get => Price + OrderItemProducts.Sum(x => x.Price * x.Quantity); private set { } }

        public void AddOrderItemProduct(ProductId productId, decimal price, int quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(price);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            var orderItemProduct = new OrderItemProduct(Id, productId, price, quantity);
            _orderItemProducts.Add(orderItemProduct);
        }
        public void RemoveOrderItemProduct(ProductId productId)
        {
            var orderItemProduct = _orderItemProducts.FirstOrDefault(x => x.ProductId == productId);
            if (orderItemProduct is not null)
            {
                _orderItemProducts.Remove(orderItemProduct);
            }
        }
    }
}
