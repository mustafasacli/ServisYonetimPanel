﻿namespace Syp.Query.Bus
{
    using Syp.Query.Bus.Core;
    using Syp.Query.Core;
    using System;

    public class QueryBus : IQueryBus
    {
        public TQueryResult Send<TQueryResult>(IQuery<TQueryResult> query)
             where TQueryResult : class, IQueryResult
        {
            throw new NotImplementedException();
        }
    }
}
