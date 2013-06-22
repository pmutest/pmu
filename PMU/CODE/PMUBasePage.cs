using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PMU.CODE
{
    public class PMUBasePage : System.Web.UI.Page
    {
        public PMUBasePage()
        {
            this.Load += new EventHandler(this.Page_Load);
        }

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
            //check if session state exists and userid is in session
            if (!RequestHasSession || Session["UserID"] == null)
            {
                Response.Redirect("Home.aspx?key=expired", false);
            }
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

        public static bool RequestHasSession
        {
            get
            {
                return (HttpContext.Current.Handler is IRequiresSessionState || HttpContext.Current.Handler is IReadOnlySessionState);
            }
        }
    }
}