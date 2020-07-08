using SimpleInfra.Common.Response;
using SimpleInfra.Crud.Extensions.ConnectionExtensions;
using Syp.Command.Insert;
using Syp.CommandHandler.Base;
using System;

namespace Syp.Command.Handlers.Insert
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceInsertCommandHandler : BaseCommandHandler<ServiceInsertCommand>
    {
        public override SimpleResponse Handle(ServiceInsertCommand command)
        {
            var response = new SimpleResponse();

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