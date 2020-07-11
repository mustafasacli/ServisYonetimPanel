namespace Syp.CommandHandler.Core
{
    using SimpleInfra.Common.Response;
    using Syp.Command.Core;

    public interface ICommandHandler<TCommand, TCommandResult>
        where TCommand : class, ICommand<TCommandResult>
        where TCommandResult : class, ICommandResult
    {
        SimpleResponse<TCommandResult> Handle(TCommand command);
    }
}