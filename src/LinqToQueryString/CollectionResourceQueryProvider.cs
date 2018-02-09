using System.Linq;
using System.Linq.Expressions;

namespace LinqToQueryString
{
    internal class CollectionResourceQueryProvider<TResult> : IQueryProvider
    {
        public CollectionResourceQueryProvider()
        {
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public TResult1 Execute<TResult1>(Expression expression)
        {
            throw new System.NotImplementedException();
        }
    }
}