using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerceBackend.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
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

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                var createdDateProp = entity.GetType().GetProperty("CreatedDate");
                var updatedDateProp = entity.GetType().GetProperty("UpdatedDate");

                if (entry.State == EntityState.Added)
                {
                    if (createdDateProp != null && createdDateProp.PropertyType == typeof(DateTime?))
                    {
                        createdDateProp.SetValue(entity, DateTime.UtcNow);
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (updatedDateProp != null && updatedDateProp.PropertyType == typeof(DateTime?))
                    {
                        updatedDateProp.SetValue(entity, DateTime.UtcNow);
                    }
                }
            }
        }
    }
}
