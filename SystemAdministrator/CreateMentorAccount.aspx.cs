using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class CreateMentorAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMentorStatus.Text = "";
        }

        protected void btnMentorConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Mentor objMentor = new Mentor();

                objMentor.name = txtMentorName.Text;
                objMentor.emailAddr = txtMentorEmail.Text;

                int id = objMentor.add();

                lblMentorID.Text = id.ToString();

                lblMentorStatus.Text = "Mentor record successfully inserted";
                txtMentorEmail.Text = "";
                txtMentorName.Text = "";
            }
        }

        protected void cuvMentorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                Mentor objMentor = new Mentor();

                if (objMentor.isEmailExist(txtMentorEmail.Text) == true)
                {
                    args.IsValid = false;
                    cuvMentorEmail.ErrorMessage = "Email address already exist";
                }              
                else
                {
                    args.IsValid = true;
                }
            }
        }

        protected void btnMentorReset_Click(object sender, EventArgs e)
        {
            txtMentorName.Text = "";
            txtMentorEmail.Text = "";
        }
    }
}