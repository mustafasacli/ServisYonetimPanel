namespace Syp.Command.Handlers.Update
{
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using SimpleInfra.Data.Extensions;
    using Syp.Command.Base.Result;
    using Syp.Command.Update;
    using SI.CommandHandler.Base;
    using System;

    public class ServiceUpdateCommandHandler :
            BaseCommandHandler<ServiceUpdateCommand, LongCommandResult>
    {
        public ServiceUpdateCommandHandler()
        {
        }

        public override SimpleResponse<LongCommandResult> Handle(ServiceUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>()
            { Data = new LongCommandResult { ReturnValue = -1 } };

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