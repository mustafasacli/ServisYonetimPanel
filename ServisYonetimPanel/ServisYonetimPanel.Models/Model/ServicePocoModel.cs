namespace ServisYonetimPanel.Models.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServicePocoModel
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
