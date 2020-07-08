namespace Syp.CommandHandler.Core
{
    using SimpleInfra.Common.Response;
    using Syp.Command.Core;

    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        SimpleResponse Handle(TCommand command);
    }
}