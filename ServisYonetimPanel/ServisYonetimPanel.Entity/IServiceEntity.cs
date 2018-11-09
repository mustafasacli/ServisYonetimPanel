namespace ServisYonetimPanel.Entity
{
    using System;

    public interface IServiceEntity
    {
        Guid GId { get; set; }

        string Url
        { get; set; }

        string UserName
        { get; set; }

        string Password
        { get; set; }
    }
}