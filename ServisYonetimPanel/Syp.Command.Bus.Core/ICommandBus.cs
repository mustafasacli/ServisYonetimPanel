namespace Syp.Command.Bus.Core
{
    using SimpleInfra.Common.Response;
    using Syp.Command.Core;

    public interface ICommandBus
    {
        SimpleResponse<TCommandResult> Send<TCommand, TCommandResult>
            (TCommand command)
            where TCommand : class, ICommand<TCommandResult>
            where TCommandResult : class, ICommandResult;
    }
}