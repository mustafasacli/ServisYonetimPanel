namespace Syp.Command.Handlers.Delete
{
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using Syp.Command.Base.Result;
    using Syp.Command.Delete;
    using Syp.CommandHandler.Base;
    using System;

    /// <summary>
    ///
    /// </summary>
    public class ServiceDeleteCommandHandler :
        BaseCommandHandler<ServiceDeleteCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ServiceDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    response.ResponseCode = connection.Delete(command);
                    response.Data = new LongCommandResult { ReturnValue = response.ResponseCode };
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