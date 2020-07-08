namespace Syp.Command.Delete
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceDetailEntity")]
    [Table("service_detail")]
    public class ServiceDetailDeleteCommand : BaseUpdateCommand
    {
        [Key]
        public long Id
        { get; set; }
    }
}