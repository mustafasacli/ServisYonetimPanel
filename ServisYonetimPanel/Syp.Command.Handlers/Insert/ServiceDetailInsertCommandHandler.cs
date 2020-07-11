using SimpleInfra.Common.Response;
using SimpleInfra.Crud.Extensions.ConnectionExtensions;
using Syp.Command.Base.Result;
using Syp.Command.Insert;
using Syp.CommandHandler.Base;
using System;

namespace Syp.Command.Handlers.Insert
{
    public class ServiceDetailInsertCommandHandler
        : BaseCommandHandler<ServiceDetailInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ServiceDetailInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    var result = connection.InsertAndGetId(command);
                    response.ResponseCode = (int)result;
                    response.RCode = result.ToString();
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