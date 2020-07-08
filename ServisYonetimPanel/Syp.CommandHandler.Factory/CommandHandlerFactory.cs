﻿using Syp.Command.Core;
using Syp.CommandHandler.Core;
using System;

namespace Syp.CommandHandler.Factory
{
    public class CommandHandlerFactory
    {
        public static ICommandHandler<TCommand> GetCommandHandler<TCommand>()
            where TCommand : class, ICommand
        {
            throw new NotImplementedException();
        }
    }
}