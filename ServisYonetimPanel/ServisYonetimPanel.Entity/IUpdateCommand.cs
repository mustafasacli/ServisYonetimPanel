namespace ServisYonetimPanel.Entity
{
    using System;

    internal interface IUpdateCommand
    {
        int UpdatedBy { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}