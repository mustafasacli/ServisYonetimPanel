namespace Syp.Command.Insert
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceEntity")]
    [Table("service")]
    public class ServiceInsertCommand : BaseInsertCommand
    {
        public ServiceInsertCommand() : base()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public string MasterKey
        { get; set; }

        [Required]
        public string Name
        { get; set; }
    }
}