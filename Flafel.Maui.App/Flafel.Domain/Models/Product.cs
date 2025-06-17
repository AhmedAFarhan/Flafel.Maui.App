namespace Flafel.Domain.Models
{
    public class Product : Aggregate<ProductId>
    {
        private readonly List<ProductItem> _productItems = new();
        public IReadOnlyList<ProductItem> ProductItems => _productItems.AsReadOnly();

        private readonly List<ProductIngredient> _productIngredients = new();
        public IReadOnlyList<ProductIngredient> ProductIngredients => _productIngredients.AsReadOnly();

        public ProductCategoryId ProductCategoryId { get; set; } = default!;
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; }
        public string? Image { get; set; } = default!;

        public static Product Create(ProductId id, ProductCategoryId productCategoryId, string name, decimal price, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            var product = new Product
            {
                Id = id,
                ProductCategoryId = productCategoryId,
                Name = name,
                Price = price,
                Image = image,
            };

            return product;
        }
        public void Update(ProductCategoryId productCategoryId, string name, decimal price, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            Name = name;
            ProductCategoryId = productCategoryId;
            Price = price;
            Image = image;
        }

        public void AddProductItem(ProductId childProductId, int quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            var productItem = new ProductItem(Id, childProductId, quantity);
            _productItems.Add(productItem);
        }
        public void RemoveProductItem(ProductId childProductId)
        {
            var productItem = _productItems.FirstOrDefault(x => x.ChildProductId == childProductId);
            if (productItem is not null)
            {
                _productItems.Remove(productItem);
            }
        }

        public void AddProductIngredient(StockItemId stockItemId, StockItemUnitId stockItemUnitId, decimal quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            var productIngredient = new ProductIngredient(Id, stockItemId, stockItemUnitId, quantity);
            _productIngredients.Add(productIngredient);
        }
        public void RemoveProductIngredient(StockItemId stockItemId)
        {
            var productIngredient = _productIngredients.FirstOrDefault(x => x.StockItemId == stockItemId);
            if (productIngredient is not null)
            {
                _productIngredients.Remove(productIngredient);
            }
        }
    }
}
