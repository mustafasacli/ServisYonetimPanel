namespace Syp.Command.Delete
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("ServiceEntity")]
    [Table("service")]
    public class ServiceDeleteCommand : BaseUpdateCommand
    {
        [Key]
        public long Id
        { get; set; }
    }
}