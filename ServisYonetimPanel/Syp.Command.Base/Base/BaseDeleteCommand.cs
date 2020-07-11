namespace Syp.Command.Base
{
    using System;
    using System.Runtime.Serialization;

    public abstract class BaseDeleteCommand : IDeleteCommand
    {
        [DataMember]
        public long? DeletedBy
        { get; set; }

        [DataMember]
        public DateTime? DeletedOn
        { get; set; }

        [DataMember]
        public bool IsDeleted
        { get; set; }
    }
}