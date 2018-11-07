using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.Mentor
{
    public partial class PendingStudentPortfolios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayStudentProfileList();
        }

        private void displayStudentProfileList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student s WHERE MentorID = @mentorId", conn);

            string MentorID = Convert.ToString((int)Session["MentorID"]);
            cmd.Parameters.AddWithValue("@mentorId", MentorID);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daProfile = new SqlDataAdapter(cmd);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daProfile.Fill(result, "StudentProfileDetails");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            DataTable dt = result.Tables["StudentProfileDetails"];
            foreach (DataRow dr in dt.Rows)
            {
                char profilestatus = Convert.ToChar(dr["Status"]);
                if (profilestatus == Convert.ToChar("N"))
                {
                    bool updatedprofilestatus = false;
                    dr["Status"] = updatedprofilestatus;
                }
                else if (profilestatus == Convert.ToChar("Y"))
                {
                    bool updatedprofilestatus = true;
                    dr["Status"] = updatedprofilestatus;
                }
            }

            //Specify GridView to get data from table "StaffDetails"
            //in DataSet "result'
            gvStudentProfile.DataSource = result.Tables["StudentProfileDetails"];

            //Display the list of data in GridView
            gvStudentProfile.DataBind();
        }

        protected void gvStudentProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the page index to the page clicked by the user
            gvStudentProfile.PageIndex = e.NewPageIndex;
            //Display records on the new page
            displayStudentProfileList();
        }

        protected void gvStudentProfile_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvStudentProfile.Rows[e.RowIndex];
            string grant = (((CheckBox)row.FindControl("Status")).Checked).ToString();

            if (((CheckBox)row.FindControl("CheckBox1")).Checked == true)
            {
                lblMessage.Text = "yes";
            }
            else
            {
                lblMessage.Text = "no";
            }
        }
    }
}