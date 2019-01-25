namespace ServisYonetimPanel.Command
{
    using System;

    public abstract class InsertCommand : IInsertCommand, ICommand
    {
        protected InsertCommand()
        {
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = 1;
        }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}