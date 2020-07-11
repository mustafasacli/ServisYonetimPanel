namespace Syp.Command.Base
{
    using Syp.Command.Base.Result;
    using Syp.Command.Core;
    using System;

    public interface IUpdateCommand : ICommand<LongCommandResult>
    {
        long? UpdatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }

        long? UpdatedOnTicks { get; set; }
    }
}