namespace Syp.Command.Core
{
    public interface ICommand<TCommandResult>
        where TCommandResult : ICommandResult
    {
    }
}