namespace Syp.CommandHandler.Base
{
    using Mst.DexterCfg.Factory;
    using SimpleFileLogging;
    using SimpleFileLogging.Enums;
    using SimpleFileLogging.Interfaces;
    using SimpleInfra.Common.Response;
    using Syp.Command.Core;
    using Syp.CommandHandler.Core;
    using System.Data;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class BaseCommandHandler<TCommand, TCommandResult>
        : ICommandHandler<TCommand, TCommandResult>
        where TCommand : class, ICommand<TCommandResult>
        where TCommandResult : class, ICommandResult
    {
        /// <summary>
        /// Handle Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public abstract SimpleResponse<TCommandResult> Handle(TCommand command);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected virtual IDbConnection GetDbConnection()
        {
            var connTypeKey = DxCfgConnectionFactory.Instance["connTypeName"];
            IDbConnection conn = DxCfgConnectionFactory.Instance.GetConnection(connTypeKey);
            var connstrKey = DxCfgConnectionFactory.Instance["connStringName"];
            conn.ConnectionString = DxCfgConnectionFactory.Instance[connstrKey];
            return conn;
        }

        protected ISimpleLogger DayLogger
        {
            get
            {
                var logger = SimpleFileLogger.Instance;
                logger.LogDateFormatType = SimpleLogDateFormats.Day;
                return logger;
            }
        }

        protected ISimpleLogger HourLogger
        {
            get
            {
                var logger = SimpleFileLogger.Instance;
                logger.LogDateFormatType = SimpleLogDateFormats.Hour;
                return logger;
            }
        }

        protected ISimpleLogger NoneLogger
        {
            get
            {
                var logger = SimpleFileLogger.Instance;
                logger.LogDateFormatType = SimpleLogDateFormats.None;
                return logger;
            }
        }
    }
}