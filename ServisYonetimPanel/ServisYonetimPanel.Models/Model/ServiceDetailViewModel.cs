namespace ServisYonetimPanel.Models.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceDetailViewModel
    {
        public long ServiceId
        { get; set; }

        public string ServiceName
        { get; set; }

        public long ServiceDetailId
        { get; set; }

        [Required]
        public string ServiceDetailText
        { get; set; }
    }
}