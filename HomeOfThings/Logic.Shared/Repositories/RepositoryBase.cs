using Data.Interfaces.Interfaces.Repositories;
using Database.HotContext;
using Date.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Logic.Shared.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : AEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;
        private bool disposedValue;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, bool asNoTracking = true)
        {
            var query = _db as IQueryable<T>;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return asNoTracking ?
                await query.AsNoTracking().ToListAsync() :
                await query.ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
            var query = _db as IQueryable<T>;

            return asNoTracking ?
                await query.AsNoTracking().FirstOrDefaultAsync(expression) :
                await query.FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
            var query = _db as IQueryable<T>;

            return asNoTracking ?
                await query.AsNoTracking().FirstOrDefaultAsync(expression) :
                await query.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Insert(T entity)
        {
            var entry = await _db.AddAsync(entity);

            return entry.State == EntityState.Added;
        }

        public async Task<bool> InsertIfNotExists(T entity, Expression<Func<T, bool>> expression)
        {
            var query = _db as IQueryable<T>;

            var existing = await query.FirstOrDefaultAsync(expression);

            if(existing == null) 
            {
                return false;
            }

            var entry = await _db.AddAsync(entity);

            return entry.State == EntityState.Added;
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);

            if (entity != null)
            {
                _context.Remove(entity);
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
