using System.ComponentModel.DataAnnotations;

namespace ServisYonetimPanel.Entity
{
    public class ServiceEntityDetail : BaseEntity
    {
        public long ServiceEntityId { get; set; }

        public ServiceEntity Service { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string BindingName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}