namespace ServisYonetimPanel.Models.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceDetailTypeModel
    {
        public long Id
        { get; set; }

        [Required]
        public string DetailTypeName
        { get; set; }
    }
}