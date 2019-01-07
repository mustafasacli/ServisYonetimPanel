namespace ServisYonetimPanel.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceEntityUpdateCommand : UpdateCommand, IServiceEntity
    {
        public ServiceEntityUpdateCommand() : base()
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