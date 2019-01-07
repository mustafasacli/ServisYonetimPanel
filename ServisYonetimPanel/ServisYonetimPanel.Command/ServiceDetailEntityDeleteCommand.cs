namespace ServisYonetimPanel.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceDetailEntity")]
    public class ServiceDetailEntityDeleteCommand : UpdateCommand
    {
        [Key]
        public long Id
        { get; set; }
    }
}