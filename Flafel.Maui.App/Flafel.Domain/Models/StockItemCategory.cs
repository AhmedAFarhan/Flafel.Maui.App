namespace Flafel.Domain.Models
{
    public  class StockItemCategory : Entity<StockItemCategoryId>
    {
        public string Name { get; private set; } = default!;
        public string? Image { get; set; } = default!;

        public static StockItemCategory Create(StockItemCategoryId id, string name, string? image)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 150);

            if (image is not null)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(image);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(image.Length, 500);
            }

            var stockItemCategory = new StockItemCategory
            {
                Id = id,
                Name = name,
                Image = image,
            };

            return stockItemCategory;
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

