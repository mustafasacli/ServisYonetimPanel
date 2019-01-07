namespace ServisYonetimPanel.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceEntityInsertCommand : InsertCommand, IServiceEntity
    {
        public ServiceEntityInsertCommand() : base()
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