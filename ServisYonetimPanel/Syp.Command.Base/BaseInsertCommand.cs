namespace Syp.Command.Base
{
    using Syp.Command.Core;
    using System;
    using System.Runtime.Serialization;

    public class BaseInsertCommand : IInsertCommand
    {
        [DataMember]
        public long CreatedBy
        { get; set; }

        private DateTime? _createdOn = null;
        [DataMember]
        public DateTime CreatedOn
        {
            get { return _createdOn ?? DateTime.Now; }
            set { _createdOn = value; }
        }

        private long? createdOnTicks = null;
        [DataMember]
        public long CreatedOnTicks
        {
            get { return (createdOnTicks ?? this.CreatedOn.Ticks); }
            set { createdOnTicks = value; }
        }

        [DataMember]
        public bool IsDeleted
        { get; set; }
    }
}