namespace Syp.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service_detail_type")]
    public class ServiceDetailType : BaseEntity
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Detay tip ismi gereklidir.")]
        [StringLength(100, ErrorMessage = "Detay tip ismi en fazla 100 karakter olmalýdýr.")]
        [Column("detail_type_name", Order = 2, TypeName = "varchar")]
        public string DetailTypeName
        { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetailList
        { get; set; }
    }
}