using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class CreateStudentAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                displayMentor();
        }

        private void displayMentor()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Mentor", conn);

            SqlDataAdapter daMentor = new SqlDataAdapter(cmd);

            DataSet result = new DataSet();

            conn.Open();

            daMentor.Fill(result, "MentorDetails");

            conn.Close();

            ddlStudentMentor.DataSource = result.Tables["MentorDetails"];

            ddlStudentMentor.DataTextField = "Name";

            ddlStudentMentor.DataValueField = "MentorID";

            ddlStudentMentor.DataBind();

            ddlStudentMentor.Items.Insert(0, "--Select--");
        }

        protected void cuvStudentEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                Student objStudent = new Student();

                if (objStudent.isEmailExist(txtStudentEmail.Text) == true)
                {
                    args.IsValid = false;
                    cuvStudentEmail.ErrorMessage = "Email address already exist";
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }

        protected void btnStudentConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Student objStudent = new Student();

                objStudent.name = txtStudentName.Text;
                objStudent.course = txtStudentCourse.Text;
                objStudent.emailAddr = txtStudentEmail.Text;

                objStudent.mentorId = ddlStudentMentor.SelectedIndex;

                int id = objStudent.add();

                lblStudentID.Text = id.ToString();

                lblStudentStatus.Text = "Student record successfully created";
                txtStudentCourse.Text = "";
                txtStudentEmail.Text = "";
                txtStudentName.Text = "";
                ddlStudentMentor.SelectedIndex = 0;
            }
        }

        protected void btnStudentReset_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtStudentCourse.Text = "";
            txtStudentEmail.Text = "";
            lblStudentID.Text = "";
            ddlStudentMentor.SelectedIndex = 0;
        }
    }
}