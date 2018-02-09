using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqToQueryString
{
    public class CollectionResourceQueryable<TData> : IOrderedQueryable<TData>
    {
        public CollectionResourceQueryable()
        {
            Expression = Expression.Constant(this);
            var executor = new CollectionResourceExecutor<TData>(Expression);
            Provider = new CollectionResourceQueryProvider<TData>(executor);
        }

        /// <summary> 
        /// This constructor is called by Provider.CreateQuery(). 
        /// </summary> 
        /// <param name="expression"></param>
        public CollectionResourceQueryable(IQueryProvider provider, Expression expression)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));

            if (!typeof(IQueryable<TData>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException(nameof(expression));
            }
        }

        public Type ElementType
        {
            get { return typeof(TData); }
        }

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public IEnumerator<TData> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<TData>>(Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<System.Collections.IEnumerable>(Expression)).GetEnumerator();
        }
    }
}
