namespace Syp.Command.Handlers.Insert
{
    using SimpleInfra.Common.Extensions;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using SimpleInfra.Data.Extensions;
    using SimpleInfra.Validation;
    using Syp.Command.Base.Result;
    using Syp.Command.Insert;
    using Syp.CommandHandler.Base;
    using System;

    /// <summary>
    ///
    /// </summary>
    public class ServiceInsertCommandHandler
        : BaseCommandHandler<ServiceInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ServiceInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                var validationResult = command.Validate();
                if (validationResult.HasError)
                {
                    response.Data = new LongCommandResult();
                    response.ResponseCode = -200;
#if DEBUG
                    response.ResponseMessage = validationResult.AllDevValidationMessages;
#else
                    response.ResponseMessage = validationResult.AllValidationMessages;
#endif

                    return response;
                }

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.InsertAndGetId(command);
                        response.ResponseCode = (int)result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = result.ToLongNullable() };
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