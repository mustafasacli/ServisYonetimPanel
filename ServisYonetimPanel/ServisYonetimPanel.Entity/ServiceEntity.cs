namespace ServisYonetimPanel.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ServiceEntity : BaseEntity, IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public string ServiceName
        { get; set; }

        public virtual ICollection<ServiceDetailEntity> ServiceEntityDetails
        { get; set; }
    }
}