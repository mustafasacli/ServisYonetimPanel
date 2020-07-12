using Syp.Query.Core;

namespace Syp.Query.Bus.Core
{
    public interface IQueryBus
    {
        TQueryResult Send<TQueryResult>(IQuery<TQueryResult> query)
            where TQueryResult : class, IQueryResult;
    }
}