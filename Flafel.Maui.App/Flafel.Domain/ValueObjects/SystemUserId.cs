namespace Flafel.Domain.ValueObjects
{
    public record SystemUserId
    {
        public Guid Value { get; }

        private SystemUserId(Guid value) => Value = value;

        public static SystemUserId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("SystemUserId can not be empty");
            }

            return new SystemUserId(value);
        }

        public static SystemUserId? OfNullable(Guid? value)
        {
            if (value is null)
            {
                return null;
            }

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("SystemUserId can not be empty");
            }

            return new SystemUserId(value.Value);
        }
    }
}
