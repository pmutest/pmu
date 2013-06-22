using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMU.CODE.Utilities;
using PMU.CODE.Enum;
using PMU.PMUService;
using System.ServiceModel;

namespace PMU.CODE.BLogic
{
    public class UserSignUpInfo
    {
        public static string validateSignUpInputData(string userName, string emailAdd,
                                       string password, string confPassword)
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

            if (string.IsNullOrEmpty(emailAdd))
            {
                validationMessage = Constant.ErrorMessage.userEmailAddEmptyErrMsg;
                return validationMessage;
            }
            else if (!CommonFunction.IsValidEmail(emailAdd))
            {
                validationMessage = Constant.ErrorMessage.userEmailAddInvalidErrMsg;
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

            if (string.IsNullOrEmpty(confPassword))
            {
                validationMessage = Constant.ErrorMessage.userConfPasswordEmptyErrMsg;
                return validationMessage;
            }
            else if (!password.Equals(confPassword))
            {
                validationMessage = Constant.ErrorMessage.passwordMisMatchErrMsg;
                return validationMessage;
            }
            return validationMessage;
        }

        public static User InsertSignUpData(string userName, string emailAdd, string password)
        {
            string userId = string.Empty;
            string encryptedPassword  = string.Empty;

            User userInfo = new User();

            try
            {
                //Encrypt the password
                encryptedPassword = CommonFunction.Encrypt(password);

                userInfo.UserName = userName;
                userInfo.Email = emailAdd;
                userInfo.Password = encryptedPassword;

                using (PMUServiceClient client = new PMUServiceClient("WSHttpBinding_IPMUService"))
                {
                    PMUServiceResult result = new PMUServiceResult();
                    result = client.InsertUserSignUpDetails(userInfo);

                    if (result.Data == null && result.ErrorMessage.Length > 0)
                    {
                        userInfo.UserId = 0;
                    }
                }
            }
            catch (FaultException<PMUServiceResult> Fex)
            {
                ErrorLogging.LogError(Fex.Detail.ErrorMessage, Fex.Detail.ErrorDetails, "www.google.com");
                userInfo.UserId = 0;
                return userInfo;
            }

            return userInfo;
        }

        /// <summary>
        /// Check whether user exist in db with username
        /// Note: Currently this function is not using to check one
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static WSInteger IsUserExist(string userName)
        {
            WSInteger IsExist = new WSInteger();
            IsExist.IntegerValue = 0;

            try
            {
                using (PMUServiceClient client = new PMUServiceClient("WSHttpBinding_IPMUService"))
                {
                    PMUServiceResult result = new PMUServiceResult();
                    result = client.IsUserNameExist(userName);
                    IsExist = (WSInteger)result.Data;
                    if (result.Data == null && result.ErrorMessage.Length > 0)
                    {
                        IsExist.IntegerValue = 0;
                    }
                }
            }
            catch (FaultException<PMUServiceResult> Fex)
            {
                ErrorLogging.LogError(Fex.Detail.ErrorMessage, Fex.Detail.ErrorDetails, "www.google.com");
            }
            return IsExist;
        }

    }
}