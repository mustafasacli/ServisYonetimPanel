﻿namespace Syp.Command.Delete
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("service")]
    [DataContract]
    public class ServiceDeleteCommand : BaseDeleteCommand
    {
        [Key]
        [Column("id", Order = 1, TypeName = "int4")]
        [DataMember]
        public long Id
        { get; set; }
    }
}