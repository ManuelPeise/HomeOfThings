using System.Linq.Expressions;

namespace Data.Interfaces.Interfaces.Repositories
{
    public interface IRepositoryBase<T>: IDisposable where T : class
    {
        Task<List<T2>> GetAllAsync<T2>(IQueryOption<T> queryOption, Expression<Func<T, T2>>? selectExpression = null);
        Task<List<T>> GetAllAsync(IQueryOption<T> queryOption);
        Task<T> GetAsync(IQueryOption<T> queryOption);
        Task<T2> GetAsync<T2>(IQueryOption<T> queryOption, Expression<Func<T, T2>>? selectExpression = null);
        bool Remove(int id);
        void Add(T entity);
        void Update(T entity);
        Task<int> SaveAsync();
       
    }
}
