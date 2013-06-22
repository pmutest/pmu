using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PMU.PMUServices.PMUService.Contracts.Entitites
{
    [DataContract]
    public class WSBoolean : PMUServiceDataResult
    {
        [DataMember]
        public bool BooleanValue { get; set; }
    }
}
