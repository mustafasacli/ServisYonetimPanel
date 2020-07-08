namespace Syp.Command.Core
{
    using System;

    public interface IDeleteCommand : ICommand
    {
        long? DeletedBy { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}