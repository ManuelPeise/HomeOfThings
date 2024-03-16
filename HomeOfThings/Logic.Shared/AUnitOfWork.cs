using Database.HotContext;
using Date.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Logic.Shared
{
    public abstract class AUnitOfWork
    {
        private readonly DatabaseContext _context;
        public DatabaseContext Context { get => _context; }

        public AUnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public virtual async Task Save(HttpContext context)
        {
            var user = context?.User?.Identity?.Name ?? "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified ||
                x.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((AEntityBase)entry.Entity).UpdatedAt = DateTime.Now;
                ((AEntityBase)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((AEntityBase)entry.Entity).CreatedAt = DateTime.Now;
                    ((AEntityBase)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
