namespace ServisYonetimPanel.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ServiceDetailEntity : BaseEntity, IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public long ServiceEntityId
        { get; set; }

        public long ServiceDetailTypeId
        { get; set; }

        public string ServiceDetailInfo
        { get; set; }

        public virtual ServiceDetailType ServiceDetailType
        { get; set; }
    }
}