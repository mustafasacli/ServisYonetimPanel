namespace Syp.Entity
{
    using Syp.Entity;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using static System.DateTime;

    public abstract class BaseEntity
    {
        private DateTime? _createdOn = null;
        /// <summary>
        /// Gets and Sets the CreatedOn
        /// </summary>
        [Column("created_on", Order = 3, TypeName = "timestamp")]
        public DateTime CreatedOn
        {
            get { return _createdOn ?? Now; }
            set { _createdOn = value; }
        }

        /// <summary>
        /// Gets and Sets the CreatedBy
        /// </summary>
        [Column("created_by", Order = 4, TypeName = "int4")]
        public int CreatedBy
        { get; set; }

        private DateTime? _updatedOn = null;
        /// <summary>
        /// Gets and Sets the UpdatedOn
        /// </summary>
        [Column("updated_on", Order = 5, TypeName = "timestamp")]
        public DateTime? UpdatedOn
        {
            get { return _updatedOn ?? Now; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// Gets and Sets the UpdatedBy
        /// </summary>
        [Column("updated_by", Order = 6, TypeName = "int4")]
        public int? UpdatedBy
        { get; set; }

        /// <summary>
        /// Gets and Sets the IsDeleted
        /// </summary>
        [Column("is_deleted", Order = 7, TypeName = "bool")]
        public bool IsDeleted
        { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ServiceUser ServiceUserCreatedBy
        { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ServiceUser ServiceUserUpdatedBy
        { get; set; }
    }
}