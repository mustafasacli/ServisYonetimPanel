namespace Syp.Dtos
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ServiceDto
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public DateTime CreatedOn
        { get; set; }

        [DataMember]
        public int CreatedBy
        { get; set; }

        [DataMember]
        public DateTime? UpdatedOn
        { get; set; }

        [DataMember]
        public int? UpdatedBy
        { get; set; }

        [DataMember]
        public bool IsDeleted
        { get; set; }
    }
}