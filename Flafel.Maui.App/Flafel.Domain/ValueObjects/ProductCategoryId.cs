namespace Flafel.Domain.ValueObjects
{
    public record ProductCategoryId
    {
        public Guid Value { get; }

        private ProductCategoryId(Guid value) => Value = value;

        public static ProductCategoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("ProductCategoryId can not be empty");
            }

            return new ProductCategoryId(value);
        }
    }
}
