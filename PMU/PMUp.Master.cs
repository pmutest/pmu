using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMU.CODE.BLogic;

namespace PMU
{
    public partial class PMUp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            string userName = txtSignInUserName.Value.Trim();
            string password = txtSignInPassword.Value;
            string validateInput = string.Empty;
            bool IsUserExist = false;

            validateInput = LoginDetail.validateSignInData(userName, password);

            if (validateInput == string.Empty)
            {
                IsUserExist = LoginDetail.IsAuthorizedUser(userName, password);
            }
        }
    }
}