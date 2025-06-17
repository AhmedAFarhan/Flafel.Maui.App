namespace Flafel.Domain.ValueObjects
{
    public record CrewId
    {
        public Guid Value { get; }

        private CrewId(Guid value) => Value = value;

        public static CrewId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CrewId can not be empty");
            }

            return new CrewId(value);
        }

        public static CrewId? OfNullable(Guid? value)
        {
            if(value is null)
            {
                return null;
            }

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CrewId can not be empty");
            }

            return new CrewId(value.Value);
        }
    }
}
