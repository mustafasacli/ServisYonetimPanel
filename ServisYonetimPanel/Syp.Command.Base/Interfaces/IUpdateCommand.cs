namespace Syp.Command.Base
{
    using Command.Base.Result;
    using SI.Command.Core;
    using System;

    public interface IUpdateCommand : ICommand<LongCommandResult>
    {
        long? UpdatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }

        long? UpdatedOnTicks { get; set; }

        bool IsDeleted { get; set; }
    }
}