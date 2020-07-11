namespace Syp.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("service_user")]
    public class ServiceUser
    {
        /// <summary>
        /// Gets and Sets the Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1, TypeName = "int4")]
        public int Id
        { get; set; }

        /// <summary>
        /// Gets and Sets the UserName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [Column("user_name", Order = 2, TypeName = "varchar")]
        public string UserName
        { get; set; }

        /// <summary>
        /// Gets and Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [Column("first_name", Order = 3, TypeName = "varchar")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets and Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [Column("last_name", Order = 4, TypeName = "varchar")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets and Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [Column("email", Order = 5, TypeName = "varchar")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets and Sets the Password
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [Column("password", Order = 6, TypeName = "varchar")]
        public string Password
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        [Column("created_on", Order = 7, TypeName = "timestamp")]
        public DateTime CreatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        [Column("created_by", Order = 8, TypeName = "int4")]
        public int? CreatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedOn
        /// </summary>
        [Column("updated_on", Order = 9, TypeName = "timestamp")]
        public DateTime? UpdatedOn
        { get; set; }

        /// <summary>
        /// Gets and Sets the UpdatedBy
        /// </summary>
        [Column("updated_by", Order = 10, TypeName = "int4")]
        public int? UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the IsDeleted
        /// </summary>
        [Column("is_deleted", Order = 11, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ServiceUser ServiceUserCreatedBy
        { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ServiceUser ServiceUserUpdatedBy
        { get; set; }

        public virtual ICollection<Service> ServiceList
        { get; set; }

        public virtual ICollection<ServiceDetailType> ServiceDetailTypeList
        { get; set; }

        public virtual ICollection<ServiceUser> ServiceUserList
        { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetailList
        { get; set; }
    }
}