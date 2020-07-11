namespace Syp.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServiceViewModel
    {
        /// <summary>
        /// Gets and Sets the Id
        /// </summary>
        [Key]
        public int Id
        { get; set; }

        /// <summary>
        /// Gets and Sets the Name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        public DateTime CreatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        public int CreatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedOn
        /// </summary>
        public DateTime? UpdatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedBy
        /// </summary>
        public int? UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the IsDeleted
        /// </summary>
        public bool IsDeleted
        { get; set; }
    }
}