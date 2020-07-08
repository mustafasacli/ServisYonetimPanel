namespace Syp.Command.Core
{
    using System;

    public interface IInsertCommand : ICommand
    {
        long CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        long CreatedOnTicks { get; set; }
    }
}