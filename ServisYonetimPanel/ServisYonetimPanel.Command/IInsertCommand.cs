namespace ServisYonetimPanel.Command
{
    using System;

    internal interface IInsertCommand
    {
        long CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }
    }
}