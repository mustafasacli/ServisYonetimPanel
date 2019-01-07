namespace ServisYonetimPanel.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceDetailEntity")]
    public class DetailRecord
    {
        public DetailRecord()
        {
        }

        public long Id
        { get; set; }

        public long MasterId
        { get; set; }

        public string DetailKey
        { get; set; }

        public string DetailValue
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

        public virtual MasterRecord Master
        { get; set; }
    }
}