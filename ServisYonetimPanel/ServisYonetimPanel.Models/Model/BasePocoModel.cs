using System;

namespace ServisYonetimPanel.Models.Model
{
    public abstract class BasePocoModel
    {
        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}