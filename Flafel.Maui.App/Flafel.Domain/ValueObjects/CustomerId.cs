﻿namespace Flafel.Domain.ValueObjects
{
    public record CustomerId
    {
        public Guid Value { get; }

        private CustomerId(Guid value) => Value = value;

        public static CustomerId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                //Throw custom exception
                throw new DomainException("CustomerId can not be empty");
            }

            return new CustomerId(value);
        }
    }
}
