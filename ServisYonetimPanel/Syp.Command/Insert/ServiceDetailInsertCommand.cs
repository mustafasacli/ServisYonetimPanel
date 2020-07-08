namespace Syp.Command.Insert
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceDetailEntity")]
    [Table("service_detail")]
    public class ServiceDetailInsertCommand : BaseInsertCommand
    {
        public ServiceDetailInsertCommand() : base()
        { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public long MasterId
        { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Detay anahtarı girilmelidir.")]
        public string DetailKey
        { get; set; }

        public string DetailValue
        { get; set; }
    }
}