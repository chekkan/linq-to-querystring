using System;
using System.Linq;
using System.Linq.Expressions;
using LinqToQueryString.Parsing;

namespace LinqToQueryString
{
    internal class SyncScalarExecutor<TResult>
    {
        private IAsyncExecutor<TResult> executor;
        private Expression expression;

        public SyncScalarExecutor(IAsyncExecutor<TResult> executor, Expression expression)
        {
            this.executor = executor;
            this.expression = expression;
        }

        internal object Execute()
        {
            this.executor.MoveNext();
            var resultOperator = executor.CompiledModel.ResultOperator;

            if (resultOperator != null && resultOperator.Value == ResultOperator.Any)
            {
                return executor.CurrentPage.Any();
            }

            if (resultOperator != null && resultOperator.Value == ResultOperator.Count)
            {
                return Convert.ToInt32(executor.Size);
            }

            if (resultOperator != null && resultOperator.Value == ResultOperator.LongCount)
            {
                return executor.Size;
            }

            if (resultOperator != null && resultOperator.Value == ResultOperator.First)
            {
                return executor.CompiledModel.ResultDefaultIfEmpty
                    ? executor.CurrentPage.FirstOrDefault()
                    : executor.CurrentPage.First();
            }

            if (resultOperator != null && resultOperator.Value == ResultOperator.Single)
            {
                return executor.CompiledModel.ResultDefaultIfEmpty
                    ? executor.CurrentPage.SingleOrDefault()
                    : executor.CurrentPage.Single();
            }

            throw new NotSupportedException("This result operator is not supported.");
        }
    }
}