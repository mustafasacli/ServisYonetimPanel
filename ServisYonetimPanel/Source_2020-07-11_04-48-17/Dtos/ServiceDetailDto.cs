namespace Syp.Dtos
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ServiceDetailDto
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public int ServiceId
        { get; set; }

        [DataMember]
        public int DetailTypeId
        { get; set; }

        [DataMember]
        public string Info
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