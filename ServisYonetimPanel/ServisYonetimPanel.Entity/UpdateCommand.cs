namespace ServisYonetimPanel.Entity
{
    using System;

    public abstract class UpdateCommand : IUpdateCommand, ICommand
    {
        protected UpdateCommand()
        {
            this.UpdatedOn = DateTime.Now;
            this.UpdatedBy = 1;
        }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}