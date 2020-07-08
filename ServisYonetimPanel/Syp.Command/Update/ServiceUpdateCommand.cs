namespace Syp.Command.Update
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceEntity")]
    [Table("service")]
    public class ServiceUpdateCommand : BaseUpdateCommand
    {
        public ServiceUpdateCommand() : base()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public string MasterKey
        { get; set; }

        public string Name
        { get; set; }
    }
}