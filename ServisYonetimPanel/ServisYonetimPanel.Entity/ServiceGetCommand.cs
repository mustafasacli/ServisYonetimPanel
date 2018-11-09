namespace ServisYonetimPanel.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServiceGetCommand : 
        IServiceEntity, IInsertCommand, IUpdateCommand, ICommand
    {
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

        public int CreatedBy
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public int UpdatedBy
        { get; set; }

        public DateTime UpdatedOn
        { get; set; }

        public bool IsActive
        { get; set; }
    }
}