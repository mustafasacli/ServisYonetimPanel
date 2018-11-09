namespace ServisYonetimPanel.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceEntityUpdateCommand : UpdateCommand, IServiceEntity
    {
        public ServiceEntityUpdateCommand() : base()
        {
        }

        [Key]
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