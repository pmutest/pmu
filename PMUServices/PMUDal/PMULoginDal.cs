//======================================================================================================
// Created By :  Vj
// Description:  Database access layer for the service methods
// For Instance: Input validation
// Created On:   6/14/2013
//======================================================================================================

using System;
using PMU.PMUServices.PMUService.Contracts.Entitites;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.ServiceLocation;
using System.Data.Common;
using System.Data;

namespace PMU.PMUServices.PMUDal
{
    public static class PMULoginDal
    {
        /// <summary>
        /// Save the signup details from a new user
        /// </summary>
        /// <param name="user">New user details</param>
        /// <returns>Saved User</returns>
        public static User InsertUserSignUpDetails(User user)
        {
            Database db = null;
            int UserId;
                     
            try
            {
                db = DatabaseFactory.CreateDatabase();
                using (DbCommand objCommand = db.GetStoredProcCommand(DalConstants.StoredProcedures.User.insertUserDetails))
                {
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.userName, DbType.String, user.UserName);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.fullName, DbType.String, user.FullName);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.gender, DbType.Boolean, user.Gender);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.email, DbType.String, user.Email);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.passWord, DbType.String, user.Password);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.isFbUser, DbType.Boolean, user.IsFbUser);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.isGmailUser, DbType.Boolean, user.IsGmailUser);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.fbUniqueId, DbType.String, user.FbUniqueId);
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.gmailUniqueId, DbType.String, user.GmailUniqueId);

                    //Excute the SP anc get the last Inserted value
                    int.TryParse(db.ExecuteScalar(objCommand).ToString(), out UserId);

                    //Assign the last inserted row id as the User Id
                    user.UserId = UserId;                    
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Check whether user exist with given UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int IsUserAllreadyExist(string userName)
        {
            int IsExist = 0;
            Database db = null;

            try
            {
                db = DatabaseFactory.CreateDatabase();
                using (DbCommand objCommand = db.GetStoredProcCommand(DalConstants.StoredProcedures.User.checkUserNameExistance))
                {
                    db.AddInParameter(objCommand, DalConstants.StoredProcedures.User.UserDetailsParameters.userName, DbType.String, userName);
                    int.TryParse(db.ExecuteScalar(objCommand).ToString(), out IsExist);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsExist;
        }
    }
}
