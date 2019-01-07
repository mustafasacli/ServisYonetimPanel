namespace ServisYonetimPanel.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceDetailEntity")]
    public class ServiceDetailEntityInsertCommand : InsertCommand
    {
        public ServiceDetailEntityInsertCommand() : base()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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