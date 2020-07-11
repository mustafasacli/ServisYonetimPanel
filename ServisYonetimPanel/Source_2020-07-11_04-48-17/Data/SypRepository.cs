namespace Syp.Data
{
    using Syp.Context;
    using SimpleInfra.Data;

    public class SypRepository<T> : SimpleBaseDataRepository<T> where T : class
    {
        public SypRepository()
             : base(new SypDbContext(), errorLogEnable: false,
                lazyLoadingEnabled: false, autoDetectChangesEnabled: false, proxyCreationEnabled: false)
        {
        }
    }
}