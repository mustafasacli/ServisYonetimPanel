namespace Syp.Command.Core
{
    using System;

    public interface IUpdateCommand : ICommand
    {
        long? UpdatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }

        long? UpdatedOnTicks { get; set; }
    }
}