namespace ServisYonetimPanel.Entity
{
    using System;

    public abstract class BaseEntity
    {
        public long CreatedBy
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public long CreatedOnUnixTimestamp
        { get; set; }

        public long? UpdatedBy
        { get; set; }

        public DateTime? UpdatedOn
        { get; set; }

        public long? UpdatedOnUnixTimestamp
        { get; set; }

        public bool IsActive
        { get; set; }
    }
}