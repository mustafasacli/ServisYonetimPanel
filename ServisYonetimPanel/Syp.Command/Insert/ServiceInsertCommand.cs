namespace Syp.Command.Insert
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("service")]
    [DataContract]
    public class ServiceInsertCommand : BaseInsertCommand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1, TypeName = "int4")]
        [DataMember]
        public long Id
        { get; set; }

        [DataMember]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Servis adı gereklidir.")]
        [StringLength(50, ErrorMessage = "Servis adı en fazla 50 karakter olmalıdır.")]
        [Column("name", Order = 2, TypeName = "varchar")]
        public string Name
        { get; set; }
    }
}