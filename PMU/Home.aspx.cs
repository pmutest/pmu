using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMU.CODE.BLogic;
using PMU.PMUService;

namespace PMU
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ResetSignUptxtFieldValue();
            }

        }       

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Value.Trim();
            string emailAdd = txtEmailAdd.Value.Trim();
            string password = txtSignUpPassword.Value;
            string confPassword = txtConfPassword.Value;
            WSInteger isExist = new WSInteger();
            isExist.IntegerValue = 0;

            string validateInput = UserSignUpInfo.validateSignUpInputData(userName, emailAdd, password, confPassword);
            User userInfo = new User();

            isExist = UserSignUpInfo.IsUserExist(userName);

            // Temprory testing condition
            if (isExist.IntegerValue == 1)
            {
                userNameErrMsg.Text = "Username Allready exist";
            }

            if (validateInput == string.Empty && isExist.IntegerValue == 0)
            {
                try
                {
                    userInfo = UserSignUpInfo.InsertSignUpData(userName, emailAdd, password);
                }
                catch (Exception ee)
                {

                }
            }
        }

        private void ResetSignUptxtFieldValue()
        {           
            txtEmailAdd.Value = string.Empty;
            txtSignUpPassword.Value = string.Empty;
            txtConfPassword.Value = string.Empty;
            txtUserName.Value = string.Empty;
        }
    }
}