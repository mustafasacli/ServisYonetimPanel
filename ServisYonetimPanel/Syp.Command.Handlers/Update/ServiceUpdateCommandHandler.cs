namespace Syp.Command.Handlers.Update
{
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using Syp.Command.Base.Result;
    using Syp.Command.Update;
    using Syp.CommandHandler.Base;
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
                    response.ResponseCode = connection.Update(command);
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