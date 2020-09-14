namespace Syp.Command.Insert
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="ServiceDetailTypeInsertCommand" />.
    /// </summary>
    [Table("service_detail_type")]
    [DataContract]
    public class ServiceDetailTypeInsertCommand : BaseInsertCommand
    {
        /// <summary>
        /// Gets or sets the Id
        /// Gets and Sets the Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1, TypeName = "int4")]
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DetailTypeName
        /// Gets and Sets the DetailTypeName.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Detay tip ismi gereklidir.")]
        [StringLength(100, ErrorMessage = "Detay tip ismi en fazla 100 karakter olmalıdır.")]
        [Column("detail_type_name", Order = 2, TypeName = "varchar")]
        public string DetailTypeName { get; set; }
    }
}
