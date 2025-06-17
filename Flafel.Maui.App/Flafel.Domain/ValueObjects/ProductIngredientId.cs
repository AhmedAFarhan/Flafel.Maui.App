namespace Flafel.Domain.ValueObjects
{
    public record ProductIngredientId
    {
        public Guid Value { get; }

        private ProductIngredientId(Guid value) => Value = value;

        public static ProductIngredientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("ProductIngredientId can not be empty");
            }

            return new ProductIngredientId(value);
        }
    }
}
