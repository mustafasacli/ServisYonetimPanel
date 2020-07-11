namespace Syp.Command.Bus
{
    using Syp.Command.Bus.Core;
    using Syp.Command.Core;
    using System;

    public class CommandBus : ICommandBus
    {
        public TCommandResult Send<TCommandResult>
            (ICommand<TCommandResult> command) where TCommandResult : ICommandResult
        {
            throw new NotImplementedException();
        }
    }
}