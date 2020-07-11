namespace Syp.Command.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public long? UpdatedOnTicks
        { get; set; }

        [DataMember]
        public bool IsDeleted
        { get; set; }
    }
}