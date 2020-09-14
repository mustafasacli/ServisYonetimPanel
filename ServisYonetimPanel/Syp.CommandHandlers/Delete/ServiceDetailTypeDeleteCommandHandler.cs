namespace Syp.CommandHandlers.Delete
{
    using SI.CommandHandler.Base;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using SimpleInfra.Data.Extensions;
    using Syp.Command.Base.Result;
    using Syp.Command.Delete;
    using System;

    /// <summary>
    /// Defines the <see cref="ServiceDetailTypeDeleteCommandHandler"/>.
    /// </summary>
    public class ServiceDetailTypeDeleteCommandHandler
        : BaseCommandHandler<ServiceDetailTypeDeleteCommand, LongCommandResult>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="command">The command <see cref="ServiceDetailTypeDeleteCommand"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LongCommandResult}"/>.</returns>
        public override SimpleResponse<LongCommandResult> Handle(ServiceDetailTypeDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>() { Data = new LongCommandResult() };

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.Delete(command);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = result };
                    }
                    finally
                    { connection.CloseIfNot(); }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }
    }
}