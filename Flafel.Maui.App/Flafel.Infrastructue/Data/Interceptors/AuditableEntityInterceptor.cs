using Flafel.Applications.Contracts.UserContext;
using Flafel.Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Flafel.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor(IUserContext userContext) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext context)
        {
            if (context is null) return;

            foreach (var entity in context.ChangeTracker.Entries<IEntity>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedBy = SystemUserId.Of(userContext.GetUserId());
                    entity.Entity.CreatedAt = DateTime.Now;
                }

                if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    entity.Entity.LastModifiedBy = SystemUserId.Of(userContext.GetUserId());
                    entity.Entity.LastModifiedAt = DateTime.Now;
                }
            }
        }
    }
}
