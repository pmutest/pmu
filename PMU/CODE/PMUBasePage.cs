using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMU.CODE
{
    public class PMUBasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        /// <summary>
        /// Name: Page_Load
        /// Purpose: Custom Page load for the base functions check the login status used 
        ///          to check whether the user is logged in or not for accessing pages which require login. 
        /// </summary>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string pageURL = Request.Url.AbsoluteUri;
            // If the Session value for the user is not set, then check the Cookie value for user's Validity.
            //if (this.Session["Username"] == null)
            //{
            //    GlobalSessionCheck oSessionCheck = new GlobalSessionCheck();
            //    if (!oSessionCheck.checkSession())
            //    {
            //        // Not a avalid User.
            //        Server.Transfer("Login.aspx");
            //        return;
            //    }
            //}
        }
    }
}