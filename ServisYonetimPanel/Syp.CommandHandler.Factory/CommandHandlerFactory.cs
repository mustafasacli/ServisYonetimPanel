using Syp.Command.Core;
using Syp.CommandHandler.Core;
using System;

namespace Syp.CommandHandler.Factory
{
    public class CommandHandlerFactory
    {
        public static ICommandHandler<TCommand, TCommandResult>
            GetCommandHandler<TCommand, TCommandResult>()
        where TCommand : class, ICommand<TCommandResult>
        where TCommandResult : class, ICommandResult
        {
            throw new NotImplementedException();
        }
    }
}