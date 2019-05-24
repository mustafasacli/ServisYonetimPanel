namespace ServisYonetimPanel.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ServiceDetailType : BaseEntity, IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public string DetailTypeName
        { get; set; }

        public virtual ICollection<ServiceDetailEntity> ServiceEntityDetails
        { get; set; }
    }
}