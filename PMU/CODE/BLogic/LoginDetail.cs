using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMU.CODE.Utilities;
using PMU.CODE.Enum;

namespace PMU.CODE.BLogic
{
    public class LoginDetail
    {
        public static string validateSignInData(string userName, string password)
        {
            string validationMessage = string.Empty;

            if (string.IsNullOrEmpty(userName))
            {
                validationMessage = Constant.ErrorMessage.userNameEmptyErrMsg;
                return validationMessage;
            }
            else if (CommonFunction.IsContains(userName, Constant.InvalidCharacterSet.invalidCharacterUseNameSet))
            {
                validationMessage = Constant.ErrorMessage.userNameInvalidErrMsg;
                return validationMessage;
            }

            if (string.IsNullOrEmpty(password))
            {
                validationMessage = Constant.ErrorMessage.userConfPasswordEmptyErrMsg;
                return validationMessage;
            }
            else if (password.Length < Convert.ToInt32(EnumValues.PasswordLength.Minimum))
            {
                validationMessage = Constant.ErrorMessage.passwordShortErrMsg;
                return validationMessage;
            }
            else if (password.Length > Convert.ToInt32(EnumValues.PasswordLength.Maximum))
            {
                validationMessage = Constant.ErrorMessage.passwordToolongErrMsg;
                return validationMessage;
            }

            return validationMessage;
        }

        public static bool IsAuthorizedUser(string userName, string password)
        {
            bool isUserExist = false;



            return isUserExist;
        }
    }
}