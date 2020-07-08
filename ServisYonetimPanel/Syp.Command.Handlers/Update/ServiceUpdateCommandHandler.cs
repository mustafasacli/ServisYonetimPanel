using SimpleInfra.Common.Response;
using SimpleInfra.Crud.Extensions.ConnectionExtensions;
using Syp.Command.Update;
using Syp.CommandHandler.Base;
using System;

namespace Syp.Command.Handlers.Update
{
    public class ServiceUpdateCommandHandler : BaseCommandHandler<ServiceUpdateCommand>
    {
        public override SimpleResponse Handle(ServiceUpdateCommand command)
        {
            var response = new SimpleResponse();

            try
            {
                using (var connection = GetDbConnection())
                {
                    response.ResponseCode = connection.Update(command);
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