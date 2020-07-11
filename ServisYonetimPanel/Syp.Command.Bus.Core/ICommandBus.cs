namespace Syp.Command.Bus.Core
{
    using Syp.Command.Core;

    public interface ICommandBus
    {
        TCommandResult Send<TCommandResult>(ICommand<TCommandResult> command)
            where TCommandResult : ICommandResult;
    }
}