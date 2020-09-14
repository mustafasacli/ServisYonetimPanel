namespace Syp.CommandHandlers.Update
{
    using SI.CommandHandler.Base;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using SimpleInfra.Data.Extensions;
    using Syp.Command.Base.Result;
    using Syp.Command.Update;
    using System;

    /// <summary>
    /// Defines the <see cref="ServiceDetailUpdateCommandHandler"/>.
    /// </summary>
    public class ServiceDetailUpdateCommandHandler :
        BaseCommandHandler<ServiceDetailUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="command">The command <see cref="ServiceDetailUpdateCommand"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LongCommandResult}"/>.</returns>
        public override SimpleResponse<LongCommandResult> Handle(ServiceDetailUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.Update(command);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = result };
                    }
                    finally
                    {
                        connection.CloseIfNot();
                    }
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