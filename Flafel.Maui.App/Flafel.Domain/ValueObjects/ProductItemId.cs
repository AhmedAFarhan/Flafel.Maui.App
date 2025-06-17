namespace Flafel.Domain.ValueObjects
{
    public record ProductItemId
    {
        public Guid Value { get; }

        private ProductItemId(Guid value) => Value = value;

        public static ProductItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("ProductItemId can not be empty");
            }

            return new ProductItemId(value);
        }
    }
}
