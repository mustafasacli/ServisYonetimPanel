namespace Syp.CommandHandlers.Update
{
    using SI.CommandHandler.Base;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Crud.Extensions.ConnectionExtensions;
    using SimpleInfra.Data.Extensions;
    using SimpleInfra.Validation;
    using Syp.Command.Base.Result;
    using Syp.Command.Update;
    using System;

    /// <summary>
    /// Defines the <see cref="ServiceUpdateCommandHandler"/>.
    /// </summary>
    public class ServiceUpdateCommandHandler :
            BaseCommandHandler<ServiceUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUpdateCommandHandler"/> class.
        /// </summary>
        public ServiceUpdateCommandHandler()
        {
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="command">The command <see cref="ServiceUpdateCommand"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LongCommandResult}"/>.</returns>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override SimpleResponse Validate(ServiceUpdateCommand command)
        {
            var response = new SimpleResponse();

            var validationResult = command.Validate();
            if (validationResult.HasError)
            {
                response.ResponseCode = -200;
#if DEBUG
                response.ResponseMessage =
                    validationResult.AllDevValidationMessages;
#else
                    response.ResponseMessage =
                        validationResult.AllValidationMessages;
#endif
            }

            return response;
        }
    }
}