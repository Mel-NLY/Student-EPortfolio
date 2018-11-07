using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.Student
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayWelcomeMessage();
        }

        public void displayWelcomeMessage()
        {
            string studentName = Session["StudentName"].ToString();
            lblWelcomeMsg.Text = "WELCOME, " + studentName + "!!!";
        }

        protected void btnUpdatePort_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/UpdatePortfolio.aspx");
        }

        protected void btnCreateProj_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/CreateProject.aspx");
        }

        protected void btnProj_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/ProjectList.aspx");
        }

        protected void btnMenSugg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/MentorSuggestion.aspx");
        }
    }
}