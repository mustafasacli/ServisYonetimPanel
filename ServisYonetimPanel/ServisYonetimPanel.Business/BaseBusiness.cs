namespace ServisYonetimPanel.Business
{
    using Dexter.Extensions;
    using DexterCfg.Factory;
    using Rocket;
    using Rocket.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public abstract class BaseBusiness
    {
        protected readonly IRcDatabase rcDb;

        protected BaseBusiness()
        {
            //Get Setting Values from dexter config file. dexter.cfg.xml
            string connKey = DxCfgConnectionFactory.Instance["conn-key"];
            string connStrKey = DxCfgConnectionFactory.Instance["conn-string-key"];

            if (string.IsNullOrWhiteSpace(connKey))
                connKey = "main";

            if (string.IsNullOrWhiteSpace(connStrKey))
                connStrKey = "mainConnStr";

            var connStr = DxCfgConnectionFactory.Instance[connStrKey];

            var dbConn = DxCfgConnectionFactory.Instance.GetConnection(connKey);
            dbConn.ConnectionString = connStr;

            rcDb = new RxDatabase(dbConn);
        }

        protected virtual object InternalAdd<T>(T entity) where T : class
        {
            var o = rcDb.InsertAndGetIdWIT(entity);
            return o;
        }

        protected virtual object InternalUpdate<T>(T entity) where T : class
        {
            var o = rcDb.UpdateWIT(entity);
            return o;
        }

        protected virtual object InternalDelete<T>(object id) where T : class
        {
            var o = rcDb.DeletByIdWIT<T>(id);
            return o;
        }

        protected virtual IEnumerable<T> InternalGetList<T>() where T : class
        {
            var t = rcDb.GetAll<T>();
            return t.AsEnumerable();
        }

        protected virtual T InternalGet<T>(object id) where T : class
        {
            var t = rcDb.GetById<T>(id);
            return t;
        }

        protected virtual IEnumerable<T> InternalGetListWithParam<T>(string sql, CommandType commandType = CommandType.Text
            , Dictionary<string, object> inputs = null, Dictionary<string, object> outputs = null) where T : class
        {
            var t = rcDb.GetDynamicResultSet(sql, commandType, mTrans: null, inputArgs: inputs, outputArgs: outputs);
            var list = t.ConvertToList<T>();
            return list.AsEnumerable();
        }

        protected void LogException(Exception e)
        {
            try
            {
                InternalServiceLogHelper.LogException(e);
            }
            catch (Exception ee)
            {
                InternalServiceLogHelper.LogException(ee);
            }
        }
    }
}