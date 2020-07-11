namespace Syp.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service_detail_type")]
    public class ServiceDetailType
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
        /// Gets and Sets the DetailTypeName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [Column("detail_type_name", Order = 2, TypeName = "varchar")]
        public string DetailTypeName
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        [Column("created_on", Order = 3, TypeName = "timestamp")]
        public DateTime CreatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        [Column("created_by", Order = 4, TypeName = "int4")]
        public int CreatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedOn
        /// </summary>
        [Column("updated_on", Order = 5, TypeName = "timestamp")]
        public DateTime? UpdatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedBy
        /// </summary>
        [Column("updated_by", Order = 6, TypeName = "int4")]
        public int? UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the IsDeleted
        /// </summary>
        [Column("is_deleted", Order = 7, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ServiceUser ServiceUser
        { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ServiceUser ServiceUser
        { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetailList
        { get; set; }
    }
}