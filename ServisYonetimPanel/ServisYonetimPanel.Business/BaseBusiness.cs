namespace ServisYonetimPanel.Business
{
    using Dexter.Extensions;
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
        private static IDbConnection BuildDbInstance()
        {
            // Get Setting Values from dexter config file. dexter.cfg.xml
            string connKey = DxCfgConnectionFactory.Instance["conn-key"];
            string connStrKey = DxCfgConnectionFactory.Instance["conn-string-key"];

            if (string.IsNullOrWhiteSpace(connKey))
                connKey = "main";

            if (string.IsNullOrWhiteSpace(connStrKey))
                connStrKey = "mainConnStr";

            var connectionString = DxCfgConnectionFactory.Instance[connStrKey];

            var dbConnection = DxCfgConnectionFactory.Instance.GetConnection(connKey);
            dbConnection.ConnectionString = connectionString;
            return dbConnection;
        }

        private static Lazy<IRcDatabase> dbInstance = new Lazy<IRcDatabase>(() =>
        {
            var dbConnection = BuildDbInstance();
            var db = new RxDatabase(dbConnection);
            return db;
        }
        );

        protected IRcDatabase Database => dbInstance.Value;

        protected BaseBusiness()
        {
        }

        protected virtual object InternalAdd<T>(T entity) where T : class
        {
            var result = Database.InsertAndGetIdWIT(entity);
            return result;
        }

        protected virtual object InternalUpdate<T>(T entity) where T : class
        {
            var result = Database.UpdateWIT(entity);
            return result;
        }

        protected virtual object InternalDelete<T>(object id) where T : class
        {
            var result = Database.DeletByIdWIT<T>(id);
            return result;
        }

        protected virtual IEnumerable<T> InternalGetList<T>() where T : class
        {
            var result = Database.GetAll<T>();
            return result.AsEnumerable();
        }

        protected virtual T InternalGet<T>(object id) where T : class
        {
            var result = Database.GetById<T>(id);
            return result;
        }

        protected virtual IEnumerable<T> InternalGetListWithParam<T>(string sql, CommandType commandType = CommandType.Text
            , Dictionary<string, object> inputs = null, Dictionary<string, object> outputs = null) where T : class
        {
            var result = Database.GetDynamicResultSet(
                sql, commandType, mTrans: null, inputArgs: inputs, outputArgs: outputs);
            var list = result.ConvertToList<T>();
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