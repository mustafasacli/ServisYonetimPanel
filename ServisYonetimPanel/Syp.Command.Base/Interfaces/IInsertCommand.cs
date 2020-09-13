namespace Syp.Command.Base
{
    using Command.Base.Result;
    using SI.Command.Core;
    using System;

    public interface IInsertCommand : ICommand<LongCommandResult>
    {
        long CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        long CreatedOnTicks { get; set; }

        bool IsDeleted { get; set; }
    }
}