using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class SystemAdminTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] != null && Session["AdminID"] != null)
            {
                lblLoginIdSysAdmin.Text = (string)Session["LoginID"];
            }
            else //user is not logged in
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}