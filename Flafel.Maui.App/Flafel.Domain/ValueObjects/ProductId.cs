namespace Flafel.Domain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }

        private ProductId(Guid value) => Value = value;

        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("ProductId can not be empty");
            }

            return new ProductId(value);
        }
    }
}
