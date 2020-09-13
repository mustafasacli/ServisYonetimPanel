using SI.Command.Core;

namespace Syp.Command.Base.Result
{
    public class LongCommandResult : ICommandResult
    {
        public long? ReturnValue { get; set; }
    }
}