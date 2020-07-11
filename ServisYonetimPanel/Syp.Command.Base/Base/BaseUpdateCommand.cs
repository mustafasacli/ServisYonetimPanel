namespace Syp.Command.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using static System.DateTime;

    public abstract class BaseUpdateCommand : IUpdateCommand
    {
        private DateTime? updatedOn = null;
        [DataMember]
        [Column("updated_on", Order = 5, TypeName = "timestamp")]
        public DateTime? UpdatedOn
        {
            get { return updatedOn ?? Now; }
            set { updatedOn = value; }
        }

        [DataMember]
        [Column("updated_by", Order = 6, TypeName = "int4")]
        public long? UpdatedBy
        { get; set; }

        private long? updatedOnTicks = null;
        [DataMember]
        [NotMapped]
        public long? UpdatedOnTicks
        {
            get { return (updatedOnTicks ?? this.UpdatedOn?.Ticks); }
            set { updatedOnTicks = value; }
        }

        [DataMember]
        [Column("is_deleted", Order = 7, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }
    }
}