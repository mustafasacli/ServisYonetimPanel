namespace ServisYonetimPanel.Business
{
    using DexterCfg.Factory;
    using Rocket;
    using Rocket.Interfaces;
    using Rocket.ConnectionExtensions;
    using Rocket.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public abstract class BaseBusiness
    {
        protected IDbConnection Connection { get; set; }

        // private IRcDatabase rcDb = null;
        // private readonly IDbConnection dbConn;

        protected BaseBusiness()
        {
            // Get Setting Values from dexter config file. dexter.cfg.xml
            string connKey = DxCfgConnectionFactory.Instance["conn-key"];
            string connStrKey = DxCfgConnectionFactory.Instance["conn-string-key"];

            if (string.IsNullOrWhiteSpace(connKey))
                connKey = "main";

            if (string.IsNullOrWhiteSpace(connStrKey))
                connStrKey = "mainConnStr";

            var connStr = DxCfgConnectionFactory.Instance[connStrKey];

            this.Connection = DxCfgConnectionFactory.Instance.GetConnection(connKey);
            this.Connection.ConnectionString = connStr;

            ////rcDb = new RxDatabase(dbConn);
        }


        protected virtual object InternalAdd<T>(T entity) where T : class
        {
            // object o = RxCrudFactory.InsertAndGetIdWIT(dbConn, entity);
            // var o = rcDb.InsertAndGetIdWIT(entity);
            var o = this.Connection.InsertAndGetIdWIT(entity);

            return o;
        }

        protected virtual object InternalUpdate<T>(T entity) where T : class
        {
            // var o = RxCrudFactory.UpdateWIT(dbConn, entity);
            // var o = rcDb.UpdateWIT(entity);
            var o = this.Connection.UpdateWIT(entity);
            return o;
        }

        protected virtual object InternalDelete<T>(object id) where T : class
        {
            // var o = RxCrudFactory.DeleteWIT(dbConn, id);
            // var o = rcDb.DeletByIdWIT<T>(id);
            var o = this.Connection.DeleteByIdWIT<T>(id);
            return o;
        }

        protected virtual IEnumerable<T> InternalGetList<T>() where T : class
        {
            // var t = RxGetFactory.GetAll<T>(dbConn);
            var t = this.Connection.GetAll<T>();
            return t.AsEnumerable();
        }

        protected virtual T InternalGet<T>(object id) where T : class
        {
            // var t = RxGetFactory.GetById<T>(dbConn, id);
            var t = this.Connection.GetById<T>(id);
            return t;
        }
    }
}