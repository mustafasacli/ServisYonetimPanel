namespace ServisYonetimPanel.Models.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceDetailModel : ServiceDetailTypeModel
    {
        public long ServiceId
        { get; set; }

        public long ServiceDetailId
        { get; set; }

        [Required]
        public string ServiceDetailText
        { get; set; }
    }
}