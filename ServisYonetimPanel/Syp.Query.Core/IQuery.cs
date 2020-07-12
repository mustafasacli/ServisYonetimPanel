namespace Syp.Query.Core
{
    public interface IQuery<TResult>
        where TResult : class, IQueryResult
    { }
}