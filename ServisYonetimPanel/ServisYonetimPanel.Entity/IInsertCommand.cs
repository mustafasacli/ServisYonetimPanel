namespace ServisYonetimPanel.Entity
{
    using System;

    internal interface IInsertCommand
    {
        int CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }
    }
}