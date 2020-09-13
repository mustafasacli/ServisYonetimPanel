﻿namespace Syp.Command.Bus
{
    using SimpleInfra.Common.Response;
    using SI.CommandBus.Core;
    using SI.Command.Core;
    using SI.CommandHandler.Factory;
    using System;

    public class CommandBus : ICommandBus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TCommandResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public SimpleResponse<TCommandResult> Send<TCommand, TCommandResult>
            (TCommand command)
            where TCommand : class, ICommand<TCommandResult>
            where TCommandResult : class, ICommandResult
        {
            var handler =
                CommandHandlerFactory.GetCommandHandler<TCommand, TCommandResult>();
            //throw new NotImplementedException();
            var cmdResult = handler.Handle(command);
            return cmdResult;
        }
    }
}