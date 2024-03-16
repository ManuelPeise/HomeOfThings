using System.Linq.Expressions;

namespace Date.Models.Models.Database
{
    public class QueryOption<T> where T : class
    {
        public bool AsNoTracking { get; set; }
        public Expression<Func<T, bool>> WhereExpression { get; set; }
    }
}
