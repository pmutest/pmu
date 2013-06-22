//======================================================================================================
// Created By :  Vj
// Description:  Page to add contants used in the Database access layer
// For Instance: Stored Procedure PM_InsertUserDetails
// Created On:   6/14/2013
//======================================================================================================


namespace PMU.PMUServices.PMUDal
{
    public class DalConstants
    {
        public struct StoredProcedures
        {
            public struct User
            {
                public const string insertUserDetails = "PM_InsertUserDetails";
                public const string checkUserNameExistance = "PM_CheckUserNameExistence";

                public struct UserDetailsParameters
                {
                    public const string userName = "@UserName";
                    public const string fullName = "@FullName";
                    public const string gender = "@Gender";
                    public const string email = "@Email";
                    public const string passWord = "@PassWord";
                    public const string isFbUser = "@IsFbUser";
                    public const string isGmailUser = "@IsGmailUser";
                    public const string fbUniqueId = "@FbUniqueId";
                    public const string gmailUniqueId = "@GmailUniqueId";
                    public const string imageUrl = "@ImageUrl";
                }
            }


        }
    }
}
