namespace ServisYonetimPanel.Command
{
    internal interface ICommand
    {
        bool IsActive { get; set; }
    }
}