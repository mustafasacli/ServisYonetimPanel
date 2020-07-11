namespace Syp.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service_detail")]
    public class ServiceDetail
    {
        /// <summary>
        /// Gets and Sets the Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1, TypeName = "int4")]
        public int Id
        { get; set; }

        /// <summary>
        /// Gets and Sets the ServiceId
        /// </summary>
        [Column("service_id", Order = 2, TypeName = "int4")]
        public int ServiceId
        { get; set; }

        /// <summary>
        /// Gets and Sets the DetailTypeId
        /// </summary>
        [Column("detail_type_id", Order = 3, TypeName = "int4")]
        public int DetailTypeId
        { get; set; }

        /// <summary>
        /// Gets and Sets the Info
        /// </summary>
        [Column("info", Order = 4, TypeName = "varchar")]
        public string Info
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        [Column("created_on", Order = 5, TypeName = "timestamp")]
        public DateTime CreatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        [Column("created_by", Order = 6, TypeName = "int4")]
        public int CreatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedOn
        /// </summary>
        [Column("updated_on", Order = 7, TypeName = "timestamp")]
        public DateTime? UpdatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedBy
        /// </summary>
        [Column("updated_by", Order = 8, TypeName = "int4")]
        public int? UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the IsDeleted
        /// </summary>
        [Column("is_deleted", Order = 9, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service
        { get; set; }

        [ForeignKey("DetailTypeId")]
        public virtual ServiceDetailType ServiceDetailType
        { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ServiceUser ServiceUser
        { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ServiceUser ServiceUser
        { get; set; }
    }
}