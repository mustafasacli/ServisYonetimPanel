namespace ServisYonetimPanel.Command
{
    using System;

    internal interface IInsertCommand
    {
        int CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }
    }
}