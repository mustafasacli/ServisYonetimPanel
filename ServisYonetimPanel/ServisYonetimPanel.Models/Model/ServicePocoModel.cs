namespace ServisYonetimPanel.Models.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ServicePocoModel : BasePocoModel
    {
        [Key]
        public long Id
        { get; set; }

        public string MasterKey
        { get; set; }

        [Required]
        public string Name
        { get; set; }
    }
}