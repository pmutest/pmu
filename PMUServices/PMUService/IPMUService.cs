//======================================================================================================
// Created By :  Vj
// Description:  PMU Service contracts defined
// For Instance: Input validation
// Created On:   6/14/2013
//======================================================================================================

using System.ServiceModel;
using System.ServiceModel.Web;
using PMU.PMUServices.PMUService.Contracts.Entitites;
using System.Collections.Specialized;
using System.ServiceModel.Activation;

namespace PMU.PMUServices.PMUService.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPMUService
    {
        [OperationContract]
        [FaultContract(typeof(PMUServiceResult))]
        PMUServiceResult InsertUserSignUpDetails(User user);

        //[OperationContract]
        //PMUServiceResult UpdateUser(User user);

        [OperationContract]
        [FaultContract(typeof(PMUServiceResult))]
        // This web invoke attribute is needed only in case
        // when we want to access this method from java script & jquery
        [WebInvoke(Method = "POST",BodyStyle = WebMessageBodyStyle.Wrapped,ResponseFormat = WebMessageFormat.Json)]
        PMUServiceResult IsUserNameExist(string userName);
    }

    
}
