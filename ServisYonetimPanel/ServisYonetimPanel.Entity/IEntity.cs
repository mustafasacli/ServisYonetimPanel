namespace ServisYonetimPanel.Entity
{
    public interface IEntity<T> where T : struct
    {
        T Id
        { get; set; }
    }
}