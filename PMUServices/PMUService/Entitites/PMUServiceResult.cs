using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PMU.PMUServices.PMUService.Contracts.Entitites
{
    [DataContract]
    public class PMUServiceResult
    {
        [DataMember]
        public PMUServiceDataResult Data { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorDetails { get; set; }
    }
}
