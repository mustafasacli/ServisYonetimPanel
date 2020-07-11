namespace Syp.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ServiceUserViewModel
    {
        /// <summary>
        /// Gets and Sets the Id
        /// </summary>
        [Key]
        public int Id
        { get; set; }

        /// <summary>
        /// Gets and Sets the UserName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string UserName
        { get; set; }

        /// <summary>
        /// Gets and Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets and Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets and Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets and Sets the Password
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        public string Password
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        public DateTime CreatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        public int? CreatedBy
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