namespace ServisYonetimPanel.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class MasterRecord
    {
        public MasterRecord()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        { get; set; }

        public string MasterKey
        { get; set; }

        public string Name
        { get; set; }

        public long CreatedBy
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public long? UpdatedBy
        { get; set; }

        public DateTime? UpdatedOn
        { get; set; }

        public bool IsActive
        { get; set; }

        public virtual ICollection<DetailRecord> Details
        { get; set; }
    }
}