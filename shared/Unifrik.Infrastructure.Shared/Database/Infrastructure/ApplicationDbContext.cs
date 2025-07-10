using Microsoft.EntityFrameworkCore;
using Unifrik.Domain.Shared.Entities;
using Unifrik.Infrastructure.Shared.User;

namespace Unifrik.Infrastructure.Shared.Database.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
       private readonly ICurrentUser _currentUser;
        public ApplicationDbContext(
             DbContextOptions options,
             ICurrentUser currentUser)
            : base(options)
        {
           _currentUser = currentUser;
        }

        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var auditable = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    auditable.CreatedAt = DateTime.UtcNow;
                    auditable.CreatedBy = _currentUser.Email;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditable.UpdatedAt = DateTime.UtcNow;
                    auditable.UpdatedBy = _currentUser.Email;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    auditable.DeletedAt = DateTime.UtcNow;
                    auditable.DeletedBy = _currentUser.Email;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
