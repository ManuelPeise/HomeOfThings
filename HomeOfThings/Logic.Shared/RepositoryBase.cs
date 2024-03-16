using Data.Interfaces.Interfaces.Repositories;
using Data.Interfaces.Interfaces;
using Database.HotContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Logic.Shared
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _table;
        private bool disposedValue;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(IQueryOption<T> queryOption)
        {
            var entities = new List<T>() as IQueryable<T>;

            if (queryOption.AsNoTracking)
            {
                entities = _table.AsNoTracking();
            }
            else
            {
                entities = _table.AsQueryable<T>();
            }

            return await entities.ToListAsync();
        }

        public async Task<List<T2>> GetAllAsync<T2>(IQueryOption<T> queryOption, Expression<Func<T, T2>> selectExpression)
        {
            var entities = new List<T>() as IQueryable<T>;

            if (queryOption.AsNoTracking)
            {
                entities = _table.AsNoTracking();
            }
            else
            {
                entities = _table.AsQueryable<T>();
            }

            if (!entities.Any())
            {
                return new List<T2>();
            }

            return await entities.Select(selectExpression).ToListAsync();

        }

        public async Task<T?> GetAsync(IQueryOption<T> queryOption)
        {
            if (queryOption.AsNoTracking)
            {
                return await _table.AsNoTracking()
                     .Where(queryOption.WhereExpression).AsQueryable()
                     .FirstOrDefaultAsync();
            }

            return await _table
                .Where(queryOption.WhereExpression)
                .FirstOrDefaultAsync();
        }

        public async Task<T2?> GetAsync<T2>(IQueryOption<T> queryOption, Expression<Func<T, T2>>? selectExpression)
        {
            if (queryOption.AsNoTracking)
            {
                return await _table.AsNoTracking()
                    .Where(queryOption.WhereExpression).Select(selectExpression).AsQueryable()
                    .FirstOrDefaultAsync();
            }

            return await _table
                .Where(queryOption.WhereExpression).Select(selectExpression)
                .FirstOrDefaultAsync();
        }
        
        public async Task<T?> SelectAsync(IQueryOption<T> queryOption)
        {
            if (queryOption.AsNoTracking)
            {
                return await _table
                    .AsNoTracking()
                    .Where(queryOption.WhereExpression)
                    .FirstOrDefaultAsync();
            }
            return await _table
                   .Where(queryOption.WhereExpression)
                   .FirstOrDefaultAsync();
        }
        
        public void Add(T entity)
        {
            _context.Add(entity).State = EntityState.Added;
        }
        
        public bool Remove(int id)
        {
            var entity = _table.Find(id);

            if (entity is { })
            {
                _table.Remove(entity);

                return true;
            }

            return false;
        }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Update(T entity)
        {
            _table.Entry(entity).State = EntityState.Modified;
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
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}