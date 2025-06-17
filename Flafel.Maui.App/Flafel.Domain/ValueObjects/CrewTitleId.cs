namespace Flafel.Domain.ValueObjects
{
    public record CrewTitleId
    {
        public Guid Value { get; }

        private CrewTitleId(Guid value) => Value = value;

        public static CrewTitleId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CrewTitleId can not be empty");
            }

            return new CrewTitleId(value);
        }
    }
}
