namespace Syp.Command.Base
{
    using Syp.Command.Base.Result;
    using Syp.Command.Core;
    using System;

    public interface IDeleteCommand : ICommand<LongCommandResult>
    {
        long? DeletedBy { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}