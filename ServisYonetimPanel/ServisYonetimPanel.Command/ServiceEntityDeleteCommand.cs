namespace ServisYonetimPanel.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceEntityDeleteCommand : UpdateCommand
    {
        [Key]
        public long Id
        { get; set; }
    }
}