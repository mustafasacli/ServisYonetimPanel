namespace Syp.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service_detail")]
    public class ServiceDetail:BaseEntity
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

        [ForeignKey("ServiceId")]
        public virtual Service Service
        { get; set; }

        [ForeignKey("DetailTypeId")]
        public virtual ServiceDetailType ServiceDetailType
        { get; set; }
    }
}