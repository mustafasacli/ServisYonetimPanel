using SimpleInfra.Common.Response;
using SimpleInfra.Crud.Extensions.ConnectionExtensions;
using Syp.Command.Delete;
using Syp.CommandHandler.Base;
using System;

namespace Syp.Command.Handlers.Delete
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceDeleteCommandHandler : BaseCommandHandler<ServiceDeleteCommand>
    {
        public override SimpleResponse Handle(ServiceDeleteCommand command)
        {
            var response = new SimpleResponse();

            try
            {
                using (var connection = GetDbConnection())
                {
                    response.ResponseCode = connection.Delete(command);
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