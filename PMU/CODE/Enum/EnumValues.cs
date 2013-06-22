using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMU.CODE.Enum
{
    public class EnumValues
    {
        public enum UserData
        {
            IsEmail,
            IsUserName
        };

        public enum PasswordLength
        {
            Minimum=7,
            Maximum =15
        };
    }
}