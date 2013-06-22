using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace PMU.PMUServices.PMUService.Contracts.Entitites
{
    [DataContract, Serializable]
    [KnownType(typeof(User))]
    [KnownType(typeof(WSString))]
    [KnownType(typeof(WSInteger))]
    [KnownType(typeof(WSBoolean))]
    //Add known types here

    public class PMUServiceDataResult
    {
        
    }
}
