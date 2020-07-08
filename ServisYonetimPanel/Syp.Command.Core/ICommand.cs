namespace Syp.Command.Core
{
    public interface ICommand
    {
        bool IsDeleted { get; set; }
    }
}