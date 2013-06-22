//======================================================================================================
// Created By :  Vj
// Description:  PMU bussiness logic for service layer defined
// For Instance: Input validation
// Created On:   6/14/2013
//======================================================================================================

using System;
using PMU.PMUServices.PMUService.Contracts.Entitites;
using PMU.PMUServices.PMUDal;

namespace PMU.PMUServices.PMULogic
{
    public static class PMULoginManager
    {    
        /// <summary>
        /// Call to the Data access layer to save signup details from a new user
        /// </summary>
        /// <param name="user">New user details</param>
        /// <returns>Saved user</returns>
        public static User InsertUserSignUpDetails(User user)
        {
            User insertedUser = null;
            try
            {
                insertedUser = new User();

                //Call to the data access layer to insert the value to Db
                insertedUser = PMULoginDal.InsertUserSignUpDetails(user);             

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int IsUserAllreadyExist(string userName)
        {
            int IsExist = 0;
            try
            {
                // Call to the data access layer to serach the username in db
                IsExist = PMULoginDal.IsUserAllreadyExist(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsExist;
        }
    }
}
