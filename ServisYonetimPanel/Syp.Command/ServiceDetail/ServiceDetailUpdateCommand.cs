﻿namespace Syp.Command.Update
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("service_detail")]
    [DataContract]
    public class ServiceDetailUpdateCommand : BaseUpdateCommand
    {
        /// <summary>
        /// Gets and Sets the Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1, TypeName = "int4")]
        [DataMember]
        public int Id
        { get; set; }

        /// <summary>
        /// Gets and Sets the ServiceId
        /// </summary>
        [Column("service_id", Order = 2, TypeName = "int4")]
        [DataMember]
        public int ServiceId
        { get; set; }

        /// <summary>
        /// Gets and Sets the DetailTypeId
        /// </summary>
        [Column("detail_type_id", Order = 3, TypeName = "int4")]
        [DataMember]
        public int DetailTypeId
        { get; set; }

        /// <summary>
        /// Gets and Sets the Info
        /// </summary>
        [Column("info", Order = 4, TypeName = "varchar")]
        [DataMember]
        public string Info
        { get; set; }
    }
}