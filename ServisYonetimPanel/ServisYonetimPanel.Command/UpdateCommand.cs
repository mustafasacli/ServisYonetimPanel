namespace ServisYonetimPanel.Command
{
    using System;

    public abstract class UpdateCommand : IUpdateCommand, ICommand
    {
        protected UpdateCommand()
        {
            this.UpdatedOn = DateTime.Now;
            this.UpdatedBy = 1;
        }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}