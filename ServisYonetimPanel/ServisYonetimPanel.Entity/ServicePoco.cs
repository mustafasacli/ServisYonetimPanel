namespace ServisYonetimPanel.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServicePoco
    {
        public Guid GId
        { get; set; }

        [Required]
        public string Url
        { get; set; }

        [Required]
        public string UserName
        { get; set; }

        [Required]
        public string Password
        { get; set; }
    }
}