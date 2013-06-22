using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMU.CODE.Utilities
{
    public class Constant
    {
        public class InvalidCharacterSet
        {
            public static List<string>
                invalidCharacterUseNameSet = new List<string>(){
                                                             "~","!","@","#","$","%","^","&","*",
                                                             "(",")","_","-","+","=",";",":",".",
                                                             "<",">","?","}","{","]","[","|","/","'"
               };
        }

        public class PageName
        {
           public const string preLoginHome = "Home.aspx";
        }

        public class StoredProcName
        {

        }

        public class ErrorMessage
        {
           public const string userNameEmptyErrMsg = "Please enter username";
           public const string userNameInvalidErrMsg = "Invalid username";
           public const string userEmailAddEmptyErrMsg = "Please enter email address";
           public const string userEmailAddInvalidErrMsg = "Invalid email address";
           public const string userPasswordEmptyErrMsg = "Please enter password";
           public const string userPasswordInvalidErrMsg = "Invalid password";
           public const string userConfPasswordEmptyErrMsg = "Please enter confirm password";
           public const string userConfPasswordInvalidErrMsg = "Invalid confirm password";
           public const string passwordShortErrMsg = "Entered password is too short";
           public const string passwordToolongErrMsg = "Entered password is too long";
           public const string passwordMisMatchErrMsg = "Eneterd password doesn't match";
        }
    }
}