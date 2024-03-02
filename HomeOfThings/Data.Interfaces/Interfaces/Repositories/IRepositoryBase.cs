using Date.Models.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces.Interfaces.Repositories
{
    public interface IRepositoryBase<T>: IDisposable where T : AEntity
    {
        Task<IList<T>> GetAllAsync(
         Expression<Func<T, bool>>? expression = null, bool asNoTracking = true);
        Task<T?> Get(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<bool> Insert(T entity);
        Task<bool> InsertIfNotExists(T entity, Expression<Func<T, bool>> expression);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
