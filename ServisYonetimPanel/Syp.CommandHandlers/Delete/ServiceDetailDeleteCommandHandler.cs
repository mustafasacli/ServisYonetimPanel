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
    /// Defines the <see cref="ServiceDetailDeleteCommandHandler"/>.
    /// </summary>
    public class ServiceDetailDeleteCommandHandler
        : BaseCommandHandler<ServiceDetailDeleteCommand, LongCommandResult>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="command">The command <see cref="ServiceDetailDeleteCommand"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LongCommandResult}"/>.</returns>
        public override SimpleResponse<LongCommandResult> Handle(ServiceDetailDeleteCommand command)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override SimpleResponse Validate(ServiceDetailDeleteCommand command)
        {
            return new SimpleResponse
            {
                ResponseCode = command.Id < 1 ? -200 : 1,
                ResponseMessage = command.Id < 1 ? "id parameter must be given." : ""
            };
        }
    }
}