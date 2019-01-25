namespace ServisYonetimPanel.Command
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiceEntity")]
    public class ServiceGetCommand :
        IServiceEntity, IInsertCommand, IUpdateCommand, ICommand
    {
        [Key]
        public long Id
        { get; set; }

        public string MasterKey
        { get; set; }

        [Required]
        public string Name
        { get; set; }

        public long CreatedBy
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public long? UpdatedBy
        { get; set; }

        public DateTime? UpdatedOn
        { get; set; }

        public bool IsActive
        { get; set; }
    }
}