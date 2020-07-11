namespace ServisYonetimPanel.Models.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceDetailPocoModel : BasePocoModel
    {
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