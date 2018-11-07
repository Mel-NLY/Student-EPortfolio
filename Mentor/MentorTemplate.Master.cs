using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1
{
    public partial class MentorTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] != null && Session["MentorID"]!=null)
            {
                lblLoginID.Text = (string)Session["LoginID"];
                lblDateTime.Text = (string)Session["LoggedInTime"];
            }
            else //Admin is not logged in
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}