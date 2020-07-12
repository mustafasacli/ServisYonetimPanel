using Syp.Query.Core;

namespace Syp.QueryHandler.Core
{
    public interface IQueryHandler<TQuery, TResult>
            where TQuery : class, IQuery<TResult>
        where TResult : class, IQueryResult
    {
        TResult Handle(TQuery query);
    }
}