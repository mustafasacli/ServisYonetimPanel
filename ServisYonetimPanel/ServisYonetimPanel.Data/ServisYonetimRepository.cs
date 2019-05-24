namespace ServisYonetimPanel.Data
{
    using SimpleInfra.Data;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServisYonetimRepository<T> : SimpleBaseDataRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public ServisYonetimRepository() : base(new ServisYonetimDbContext(), errorLogEnable: false)
        //(new ServisYonetimDbContext(), ISimpleRepoLogger simpleRepoLogger = null, bool errorLogEnable = true, bool lazyLoadingEnabled = false, bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false) : base(dbContext, simpleRepoLogger, errorLogEnable, lazyLoadingEnabled, autoDetectChangesEnabled, proxyCreationEnabled)
        {
        }
    }
}