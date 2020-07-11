using Syp.Query.Core;

namespace Syp.QueryHandler.Core
{
    public interface IQueryHandler<TQuery, TResult>
            where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}