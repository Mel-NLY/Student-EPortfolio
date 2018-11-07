using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WEBAssignmentCheckpoint1.Mentor
{
    public partial class Suggestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create a new Student, Suggestion object
            StudentClass objStudent = new StudentClass();
            Suggestion objSuggestion = new Suggestion();

            //Read Student, Suggestion from query string
            objStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            objSuggestion.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);

            //Load Student, Suggestion information to controls
            int studenterrorCode = objStudent.getDetails();
            int suggestionerrorCode = objSuggestion.getDetails();
            if (studenterrorCode == 0)
            {
                lblProfileSugg.Text = objStudent.name;
                lblProfileSuggBar.Text = objStudent.name;
            }
            else if (studenterrorCode == -2)
            {
                lblProfileSugg.Text = "Unable to retrieve Student details for ID " + objStudent.studentId;
                lblProfileSugg.ForeColor = System.Drawing.Color.Red;
            }
            displaySuggestions();
            Suggestion objAckSuggestion = new Suggestion();
            objAckSuggestion.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            objAckSuggestion.getDetails();
            StudentClass objAckStudent = new StudentClass();
            objAckStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            objAckStudent.getDetails();
            bool suggestionstatus = true; //creating a variable to set the default status of the suggestion to be acknowledged
            for (int r = 1; r <= gvSuggestions.Rows.Count-1; r++)
            {
                if (gvSuggestions.Rows[r].Cells[2].Text == "N")
                {
                    suggestionstatus = false;
                }
            }
            if (objAckStudent.status == Convert.ToChar("N") && suggestionstatus == true)
            {
                btnApproveProfile.Visible = true;
            }
            else
            {
                btnApproveProfile.Visible = false;
            }
        }
        private void displaySuggestions()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd = new SqlCommand("SELECT * FROM Suggestion s WHERE StudentID = @studentid", conn);

            cmd.Parameters.AddWithValue("@studentid", Convert.ToString(Request.QueryString["StudentId"]));

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daSuggestion = new SqlDataAdapter(cmd);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daSuggestion.Fill(result, "Suggestions");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "StaffDetails"
            //in DataSet "result'
            gvSuggestions.DataSource = result.Tables["Suggestions"];

            //Display the list of data in GridView
            gvSuggestions.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                btnApproveProfile.Visible = false;
                //Create a new object from the Suggestion Class
                StudentClass objStudent = new StudentClass();
                objStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
                objStudent.getDetails();
                Suggestion objSuggestion = new Suggestion();
                MentorClass objMentor = new MentorClass();

                objMentor.emailaddr = (string)Session["LoginID"];
                objSuggestion.mentorId = (int)Session["MentorID"];
                objSuggestion.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
                objSuggestion.description = tbSuggestions.Text;
                objSuggestion.status = Convert.ToChar("N");
                objSuggestion.dateCreated = DateTime.Now;

                //Check if the selected Student Profile status is "N", if the Mentor Suggestion is not acknowledged yet
                if (objStudent.status == Convert.ToChar("Y") && objSuggestion.status == Convert.ToChar("N"))
                {
                    //Call the add method to insert the suggestions record to database
                    objStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
                    objStudent.status = Convert.ToChar("N");
                    int updateprofilestatus = objStudent.updateprofilestatus();

                    //Call the add method to insert the suggestions record to database
                    int newsuggestionid = objSuggestion.insertsuggestions();
                    lblMessage.Text = "Reply successfully sent!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //Call the add method to insert the suggestions record to database
                    int newsuggestionid = objSuggestion.insertsuggestions();
                    lblMessage.Text = "Reply successfully sent!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnApproveProfile_Click(object sender, EventArgs e)
        {
            StudentClass objStudent = new StudentClass();
            objStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            objStudent.status = Convert.ToChar("Y");
            int updateprofilestatus = objStudent.updateprofilestatus();
            lblMessage.Text = "Profile Status updated to APPROVED!";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}