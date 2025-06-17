namespace Flafel.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public CustomerId CustomerId { get; private set; } = default!;
        public CourierId CourierId { get; private set; } = default!;
        public DeliveryAddress DeliveryAddress { get; private set; } = default!;
        public decimal DeliveryFee { get; set; }
        public decimal TaxAmount { get; set; }
        public string? Notes { get; private set; } = default!;
        public OrderStatus OrderStatus { get; private set; } = OrderStatus.PLACED;
        public PaymentMethod PaymentMethod { get; private set; } = PaymentMethod.CASH;
        public decimal TotalPrice { get => OrderItems.Sum(x => x.Price * x.Quantity) + TaxAmount + DeliveryFee; private set { } }

        public static Order Create(OrderId id, CustomerId customerId, CourierId courierId, DeliveryAddress deliveryAddress, decimal deliveryFee, decimal taxAmount, string? notes, OrderStatus orderStatus, PaymentMethod paymentMethod)
        {
            if (notes is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(notes);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(notes.Length, 250);
            }

            if (!Enum.IsDefined<OrderStatus>(orderStatus))
            {
                throw new DomainException("OrderStatus value is out of range");
            }

            if (!Enum.IsDefined<PaymentMethod>(paymentMethod))
            {
                throw new DomainException("PaymentMethod value is out of range");
            }

            ArgumentOutOfRangeException.ThrowIfNegative(deliveryFee);

            ArgumentOutOfRangeException.ThrowIfNegative(taxAmount);

            var order = new Order
            {
                Id = id,
                CustomerId = customerId,
                CourierId = courierId,
                DeliveryAddress = deliveryAddress,
                DeliveryFee = deliveryFee,
                TaxAmount = taxAmount,
                Notes = notes,
                OrderStatus = orderStatus,
                PaymentMethod = paymentMethod
            };

            //order.AddDomainEvent(new OrderCreatedEvent(order));

            return order;
        }
        public void Update(CourierId courierId, DeliveryAddress deliveryAddress, decimal deliveryFee, decimal taxAmount, string? notes, OrderStatus orderStatus, PaymentMethod paymentMethod)
        {
            if (notes is not null)
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(notes.Length, 250);
                ArgumentOutOfRangeException.ThrowIfLessThan(notes.Length, 1);
            }

            if (!Enum.IsDefined<OrderStatus>(orderStatus))
            {
                throw new DomainException("OrderStatus value is out of range");
            }

            if (!Enum.IsDefined<PaymentMethod>(paymentMethod))
            {
                throw new DomainException("PaymentMethod value is out of range");
            }

            ArgumentOutOfRangeException.ThrowIfLessThan(0, deliveryFee);

            ArgumentOutOfRangeException.ThrowIfLessThan(0, taxAmount);

            CourierId = courierId;
            DeliveryAddress = deliveryAddress;
            DeliveryFee = deliveryFee;
            TaxAmount = taxAmount;
            Notes = notes;
            OrderStatus = orderStatus;
            PaymentMethod = paymentMethod;

            //AddDomainEvent(new OrderUpdatedEvent(this));
        }

        public OrderItem AddOrderItem(ProductId productId, decimal price, int quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            var orderItem = new OrderItem(Id, productId, price, quantity);
            _orderItems.Add(orderItem);

            return orderItem;
        }
        public void RemoveOrderItem(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
            if (orderItem is not null)
            {
                _orderItems.Remove(orderItem);
            }
        }
    }
}
