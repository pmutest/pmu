using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PMU.PMUServices.PMUService.Contracts.Entitites
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class User : PMUServiceDataResult
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public bool Gender { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string P_Address1 { get; set; }

        [DataMember]
        public string P_Address2 { get; set; }

        [DataMember]
        public string P_Address3 { get; set; }

        [DataMember]
        public int P_CityId { get; set; }

        [DataMember]
        public int P_StateId { get; set; }

        [DataMember]
        public string P_PinCode { get; set; }

        [DataMember]
        public int P_CountryId { get; set; }

        [DataMember]
        public string C_Address1 { get; set; }
        
        [DataMember]
        public string C_Address2 { get; set; }

        [DataMember]
        public string C_Address3 { get; set; }

        [DataMember]
        public int C_CityId { get; set; }

        [DataMember]
        public int C_StateId { get; set; }

        [DataMember]
        public string C_PinCode { get; set; }

        [DataMember]
        public int C_CountryId { get; set; }

        [DataMember]
        public string M_Number { get; set; }

        [DataMember]
        public string T_Number { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public bool IsFbUser { get; set; }

        [DataMember]
        public string FbUniqueId { get; set; }

        [DataMember]
        public bool IsGmailUser { get; set; }

        [DataMember]
        public string GmailUniqueId { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime ModifiedOn { get; set; }

        [DataMember]
        public bool IsEnabled { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }
    }   
}
