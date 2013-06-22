//======================================================================================================
// Created By :  Vj
// Description:  Database access layer for the service methods
// For Instance: Input validation
// Created On:   6/14/2013
//======================================================================================================

using System;
using System.ServiceModel;
using PMU.PMUServices.PMUService.Contracts;
using PMU.PMUServices.PMUService.Contracts.Entitites;
using PMU.PMUServices.PMULogic;
using System.ServiceModel.Activation;

namespace PMU.PMUServices.PMUServiceLibrary
{
    // This attribute allow to method get called by Java script 
    // and Jquery this attribute make wcf service to behave as 
    // asmx (webservice)
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PMUService : IPMUService
    {
        /// <summary>
        /// Call to the bussiness logic layer to save signup details from a new user
        /// </summary>
        /// <param name="user">New user details</param>
        /// <returns>Saved user</returns>
        public PMUServiceResult InsertUserSignUpDetails(User user)
        {
            PMUServiceResult PMUServiceResultObject = new PMUServiceResult();
            User newUser = null;

            try
            {
                newUser = new User();

                //call to the bussiness logic layer to check data and insert date to the db
                newUser = PMULoginManager.InsertUserSignUpDetails(user);

                //Assign the return value to the common return type
                PMUServiceResultObject.Data = user;

                return PMUServiceResultObject;
            }
            catch (Exception ex)
            {             
                PMUServiceResultObject.ErrorDetails = ex.ToString();
                PMUServiceResultObject.ErrorMessage = "Some error, unable to insert user data";
                PMUServiceResultObject.Data = newUser;

                throw new FaultException<PMUServiceResult>(PMUServiceResultObject, ex.ToString()); 
            }
        }

        /// <summary>
        ///  Call to business logic for check any username exist 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PMUServiceResult IsUserNameExist(string userName)
        {
            PMUServiceResult PMUServiceResultObject = new PMUServiceResult();
            WSInteger IsExist = new WSInteger();

            try
            {
                // Call to business logic layer to check user exist or not
                IsExist.IntegerValue = PMULoginManager.IsUserAllreadyExist(userName);
                PMUServiceResultObject.Data = (WSInteger)IsExist;
                return PMUServiceResultObject;
            }
            catch (Exception ex)
            {
                PMUServiceResultObject.ErrorDetails = ex.ToString();
                PMUServiceResultObject.ErrorMessage = "Some error, Unable to search username";
                PMUServiceResultObject.Data = null;

                throw new FaultException<PMUServiceResult>(PMUServiceResultObject, ex.ToString());
            }
        }

        //public PMUServiceResult UpdateUser(User value)
        //{
        //    WSString str = new WSString();
        //    str.StringValue = "Calling service";

        //    PMUServiceResult PMUTestObject = new PMUServiceResult();
        //    PMUTestObject.Data = str;

        //    return PMUTestObject;
        //}
    }
}
