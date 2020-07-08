namespace Syp.Command.Base
{
    using Syp.Command.Core;
    using System;
    using System.Runtime.Serialization;

    public abstract class BaseUpdateCommand : IUpdateCommand
    {
        [DataMember]
        public long? UpdatedBy
        { get; set; }

        [DataMember]
        public DateTime? UpdatedOn
        { get; set; }

        [DataMember]
        public long? UpdatedOnTicks
        { get; set; }

        [DataMember]
        public bool IsDeleted
        { get; set; }
    }
}