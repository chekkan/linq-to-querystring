using System.Linq;
using System.Linq.Expressions;

namespace LinqToQueryString
{
    public class CollectionResourceQueryProvider<TResult> : IQueryProvider
    {
        private IAsyncExecutor<TResult> executor;

        public CollectionResourceQueryProvider(IAsyncExecutor<TResult> executor)
        {
            this.executor = executor;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new CollectionResourceQueryable<TResult>(this, expression);
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            return new CollectionResourceQueryable<T>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return new SyncScalarExecutor<TResult>(executor, expression).Execute();
        }

        public T Execute<T>(Expression expression)
        {
            return (T) new SyncScalarExecutor<TResult>(executor, expression).Execute();
        }
    }
}