using SimpleInfra.Common.Response;
using SimpleInfra.Crud.Extensions.ConnectionExtensions;
using SimpleInfra.Data.Extensions;
using Syp.Command.Base.Result;
using Syp.Command.Update;
using Syp.CommandHandler.Base;
using System;

namespace Syp.Command.Handlers.Update
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceDetailUpdateCommandHandler :
        BaseCommandHandler<ServiceDetailUpdateCommand, LongCommandResult>
    {
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