namespace ServisYonetimPanel.Command
{
    public interface IServiceEntity
    {
        long Id
        { get; set; }

        string MasterKey
        { get; set; }

        string Name
        { get; set; }
    }
}