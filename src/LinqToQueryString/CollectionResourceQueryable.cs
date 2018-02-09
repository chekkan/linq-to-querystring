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
            Provider = new CollectionResourceQueryProvider<TData>();
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
