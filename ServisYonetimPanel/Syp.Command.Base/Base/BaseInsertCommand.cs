namespace Syp.Command.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    public class BaseInsertCommand : IInsertCommand
    {
        private DateTime? _createdOn = null;

        [DataMember]
        [Column("created_on", Order = 3, TypeName = "timestamp")]
        public DateTime CreatedOn
        {
            get { return _createdOn ?? DateTime.Now; }
            set { _createdOn = value; }
        }

        [DataMember]
        [Column("created_by", Order = 4, TypeName = "int4")]
        public long CreatedBy
        { get; set; }

        private long? createdOnTicks = null;

        [DataMember]
        [NotMapped]
        public long CreatedOnTicks
        {
            get { return (createdOnTicks ?? (createdOnTicks = this.CreatedOn.Ticks).Value); }
            set { createdOnTicks = value; }
        }

        [DataMember]
        [Column("is_deleted", Order = 7, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }
    }
}