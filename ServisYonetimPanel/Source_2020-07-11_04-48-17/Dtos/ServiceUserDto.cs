namespace Syp.Dtos
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ServiceUserDto
    {
        [DataMember]
        public int Id
        { get; set; }

        [DataMember]
        public string UserName
        { get; set; }

        [DataMember]
        public string FirstName
        { get; set; }

        [DataMember]
        public string LastName
        { get; set; }

        [DataMember]
        public string Email
        { get; set; }

        [DataMember]
        public string Password
        { get; set; }

        [DataMember]
        public DateTime CreatedOn
        { get; set; }

        [DataMember]
        public int? CreatedBy
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