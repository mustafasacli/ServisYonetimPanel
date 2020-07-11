namespace Syp.Command.Base
{
    using Syp.Command.Base.Result;
    using Syp.Command.Core;
    using System;

    public interface IInsertCommand : ICommand<LongCommandResult>
    {
        long CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        long CreatedOnTicks { get; set; }
    }
}