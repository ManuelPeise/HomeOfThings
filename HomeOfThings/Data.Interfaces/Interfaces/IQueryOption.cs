using Date.Models.Entities.User;
using System.Linq.Expressions;

namespace Data.Interfaces.Interfaces
{
    public interface IQueryOption<T> where T : class 
    {
        public bool AsNoTracking { get; set; }
        public Expression<Func<T, bool>> WhereExpression  { get; set; }
    }
}
