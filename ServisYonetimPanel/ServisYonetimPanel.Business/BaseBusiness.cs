namespace ServisYonetimPanel.Business
{
    using DexterCfg.Factory;
    using Rocket;
    using Rocket.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public abstract class BaseBusiness
    {
        private IRcDatabase rcDb = null;
        //private readonly IDbConnection dbConn;

        protected BaseBusiness()
        {
            //Get Setting Values from dexter config file. dexter.cfg.xml
            var dbConn = DxCfgConnectionFactory.Instance.GetConnection("main");
            rcDb = new RxDatabase(dbConn);
        }

        protected virtual object InternalAdd<T>(T entity) where T : class
        {
            //object o = RxCrudFactory.InsertAndGetIdWIT(dbConn, entity);
            var o = rcDb.InsertAndGetIdWIT(entity);
            return o;
        }

        protected virtual object InternalUpdate<T>(T entity) where T : class
        {
            //var o = RxCrudFactory.UpdateWIT(dbConn, entity);
            var o = rcDb.UpdateWIT(entity);
            return o;
        }

        protected virtual object InternalDelete<T>(object id) where T : class
        {
            //var o = RxCrudFactory.DeleteWIT(dbConn, id);
            var o = rcDb.DeletByIdWIT<T>(id);
            return o;
        }

        protected virtual IEnumerable<T> InternalGetList<T>() where T : class
        {
            // var t = RxGetFactory.GetAll<T>(dbConn);
            var t = rcDb.GetAll<T>();
            return t.AsEnumerable();
        }

        protected virtual T InternalGet<T>(object id) where T : class
        {
            // var t = RxGetFactory.GetById<T>(dbConn, id);
            var t = rcDb.GetById<T>(id);
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