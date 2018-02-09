using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LinqToQueryString
{
    internal class CollectionResourceExecutor<TResult> : IAsyncExecutor<TResult>
    {
        private Expression expression;

        public CollectionResourceExecutor(Expression expression)
        {
            this.expression = expression;
        }

        public string CurrentHref => throw new NotImplementedException();

        public CollectionResourceQueryModel CompiledModel => throw new NotImplementedException();

        public long Offset => throw new NotImplementedException();

        public long Limit => throw new NotImplementedException();

        public long Size => throw new NotImplementedException();

        public decimal MaxScore => throw new NotImplementedException();

        public IEnumerable<TResult> CurrentPage => throw new NotImplementedException();

        public void MoveNext()
        {
            throw new NotImplementedException();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        bool IAsyncExecutor<TResult>.MoveNext()
        {
            throw new NotImplementedException();
        }
    }
}