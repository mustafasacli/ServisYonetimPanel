namespace Syp.Command.Delete
{
    using Syp.Command.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="ServiceDetailDeleteCommand" />.
    /// </summary>
    [Table("service_detail")]
    [DataContract]
    public class ServiceDetailDeleteCommand : BaseDeleteCommand
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        [Column("id", Order = 1, TypeName = "int4")]
        [DataMember]
        public long Id { get; set; }
    }
}
