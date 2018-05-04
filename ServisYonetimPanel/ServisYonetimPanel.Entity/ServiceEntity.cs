using System.ComponentModel.DataAnnotations;

namespace ServisYonetimPanel.Entity
{
    public class ServiceEntity: BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public long ServiceEntityDetailId { get; set; }

        public ServiceEntityDetail Detail { get; set; }
    }
}
