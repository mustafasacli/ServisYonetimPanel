namespace Syp.Command.Update
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceDetailEntity")]
    [Table("service_detail")]
    public class ServiceDetailUpdateCommand : BaseUpdateCommand
    {
        public ServiceDetailUpdateCommand() : base()
        {
        }

        [Key]
        public long Id
        { get; set; }

        public long MasterId
        { get; set; }

        [Required]
        public string DetailKey
        { get; set; }

        public string DetailValue
        { get; set; }
    }
}