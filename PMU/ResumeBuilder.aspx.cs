using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMU
{
    public partial class ResumeBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillResumeCategory();
            }
        }

        protected void FillResumeCategory()
        {
            List<ListItem> resumeCategory = new List<ListItem>();
            resumeCategory.Add(new ListItem("Select..", "0"));
            resumeCategory.Add(new ListItem("IT", "1"));
            resumeCategory.Add(new ListItem("CA", "2"));
            ddlResumeCategory.DataSource = resumeCategory;
            ddlResumeCategory.DataTextField = "Text";
            ddlResumeCategory.DataValueField = "Value";
            ddlResumeCategory.DataBind();
        }
    }
}