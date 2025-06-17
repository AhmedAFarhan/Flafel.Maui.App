namespace Flafel.Domain.ValueObjects
{
    public record CourierId
    {
        public Guid Value { get; }

        private CourierId(Guid value) => Value = value;

        public static CourierId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CourierId can not be empty");
            }

            return new CourierId(value);
        }
    }
}
