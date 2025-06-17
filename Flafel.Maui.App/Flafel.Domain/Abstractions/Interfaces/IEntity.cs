namespace Flafel.Domain.Abstractions.Interfaces
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        SystemUserId CreatedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
        SystemUserId? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
