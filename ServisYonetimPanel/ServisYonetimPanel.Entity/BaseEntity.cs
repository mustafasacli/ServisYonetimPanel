using System;

namespace ServisYonetimPanel.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
