namespace ServisYonetimPanel.Business
{
    using DexterCfg.Factory;
    using Rocket;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public abstract class BaseBusiness
    {
        private readonly IDbConnection dbConn;

        protected BaseBusiness()
        {
            dbConn = DxCfgConnectionFactory.Instance.GetConnection("main");
        }

        protected virtual object InternalAdd<T>(T entity) where T : class
        {
            object o = RxCrudFactory.InsertAndGetIdWIT(dbConn, entity);
            return o;
        }

        protected virtual object InternalUpdate<T>(T entity) where T : class
        {
            var o = RxCrudFactory.UpdateWIT(dbConn, entity);
            return o;
        }

        protected virtual object InternalDelete<T>(object id) where T : class
        {
            var o = RxCrudFactory.DeleteWIT(dbConn, id);
            return o;
        }

        protected virtual IEnumerable<T> InternalGetList<T>() where T : class
        {
            var t = RxGetFactory.GetAll<T>(dbConn);
            return t.AsEnumerable();
        }

        protected virtual T InternalGet<T>(object id) where T : class
        {
            var t = RxGetFactory.GetById<T>(dbConn, id);
            return t;
        }

        protected void LogException(Exception e)
        {
            try
            {
                InternalServiceLogHelper.LogException(e);
            }
            catch (Exception ee)
            {

            }
        }
    }
}