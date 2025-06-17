namespace Flafel.Domain.Models
{
    public class ProductCategory : Entity<ProductCategoryId>
    {
        public string Name { get; private set; } = default!;
        public string? Image { get; set; } = default!;

        public static ProductCategory Create(ProductCategoryId id, string name, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            var productCategory = new ProductCategory
            {
                Id = id,
                Name = name,
                Image = image,
            };

            return productCategory;
        }
        public void Update(string name, string? image)
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
    }
}
