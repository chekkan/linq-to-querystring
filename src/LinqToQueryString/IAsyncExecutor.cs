using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LinqToQueryString
{
    /// <summary>
    /// A query executor for <see cref="IAsyncQueryable{T}"/>.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IAsyncExecutor<TResult>
    {
        /// <summary>
        /// Gets the current request URL.
        /// </summary>
        /// <value>The current request URL.</value>
        string CurrentHref { get; }

        /// <summary>
        /// Gets the compiled query model.
        /// </summary>
        /// <value>The compiled query model.</value>
        CollectionResourceQueryModel CompiledModel { get; }

        /// <summary>
        /// Gets the current paging offset.
        /// </summary>
        /// <value>The current paging offset.</value>
        long Offset { get; }

        /// <summary>
        /// Gets the current paging limit.
        /// </summary>
        /// <value>The current paging limit.</value>
        long Limit { get; }

        /// <summary>
        /// Gets the current paging size.
        /// </summary>
        /// <value>The current paging size.</value>
        long Size { get; }

        /// <summary>
        /// Gets the max score of the query.
        /// </summary>
        /// <value>The maximum score of the query.</value>
        decimal MaxScore { get; }

        /// <summary>
        /// Gets the current page of results.
        /// </summary>
        /// <value>The current page of results.</value>
        IEnumerable<TResult> CurrentPage { get; }

        /// <summary>
        /// Attempts to move to the next page of collection results.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see langword="true"/> if the operation succeeded and the current values have been updated;
        /// <see langword="false"/> if the iterator has been exhausted.</returns>
        Task<bool> MoveNextAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Synchronously attempts to move to the next page of collection results.
        /// </summary>
        /// <returns><see langword="true"/> if the operation succeeded and the current values have been updated;
        /// <see langword="false"/> if the iterator has been exhausted.</returns>
        bool MoveNext();
    }
}