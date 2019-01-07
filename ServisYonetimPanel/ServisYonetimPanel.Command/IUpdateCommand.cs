namespace ServisYonetimPanel.Command
{
    using System;

    internal interface IUpdateCommand
    {
        long? UpdatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}