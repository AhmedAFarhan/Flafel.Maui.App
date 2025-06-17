using Flafel.Domain.Abstractions.Interfaces;

namespace Flafel.Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = default!;
        public SystemUserId CreatedBy { get; set; } = default!;
        public DateTime? LastModifiedAt { get; set; } = default!;
        public SystemUserId? LastModifiedBy { get; set; } = default!;
        public bool IsDeleted { get; set; } = false;
    }
}
