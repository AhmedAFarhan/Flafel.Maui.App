namespace Flafel.Domain.Abstractions.Interfaces
{
    public interface IAggregate<T> : IAggregate, IEntity<T>
    {

    }

    public interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        void AddDomainEvent(IDomainEvent domainEvent);
        IDomainEvent[] ClearDomainEvents();
    }
}
