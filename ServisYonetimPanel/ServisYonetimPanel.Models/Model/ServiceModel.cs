namespace ServisYonetimPanel.Models.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceModel
    {
        public long ServiceId
        { get; set; }

        [Required]
        public string ServiceName
        { get; set; }

        public List<ServiceDetailModel> Details
        { get; set; }
    }
}