namespace ServisYonetimPanel.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceEntityDeleteCommand : UpdateCommand
    {
        [Key]
        public Guid GId
        { get; set; }
    }
}