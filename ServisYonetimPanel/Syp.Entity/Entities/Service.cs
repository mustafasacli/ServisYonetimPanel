namespace Syp.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service")]
    public class Service : BaseEntity
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
        /// Gets and Sets the Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Servis adý gereklidir.")]
        [StringLength(50, ErrorMessage = "Servis adý en fazla 50 karakter olmalýdýr.")]
        [Column("name", Order = 2, TypeName = "varchar")]
        public string Name
        { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetailList
        { get; set; }
    }
}