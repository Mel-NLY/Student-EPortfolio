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
    public partial class StudentSkillSetSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayStudentList();
        }

        private void displayStudentList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student s INNER JOIN StudentSkillSet sss ON s.StudentID = sss.StudentID INNER JOIN SkillSet ss ON sss.SkillSetID = ss.SkillSetID", conn);
            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daStudent.Fill(result, "StudentDetails");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "StaffDetails"
            //in DataSet "result'
            gvSkillSet.DataSource = result.Tables["StudentDetails"];

            //Display the list of data in GridView
            gvSkillSet.DataBind();   
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Reset the lblNone Text to nothing
            lblNone.Text = "";

            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Student s INNER JOIN StudentSkillSet sss ON s.StudentID = sss.StudentID INNER JOIN SkillSet ss ON sss.SkillSetID = ss.SkillSetID WHERE ss.SkillSetName = @selectedskillset", conn);

            cmd1.Parameters.AddWithValue("@selectedskillset", ddlSearch.SelectedValue);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "StaffDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daStudent.Fill(result, "StudentDetails");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "StaffDetails"
            //in DataSet "result'
            gvSkillSet.DataSource = result.Tables["StudentDetails"];

            //Display the list of data in GridView
            gvSkillSet.DataBind();

            if (ddlSearch.SelectedValue == "All")
            {
                lblNone.Text = "Choose a SkillSet to start the search!";
                lblNone.ForeColor = System.Drawing.Color.Red;
            }

            else if (result.Tables["StudentDetails"].Rows.Count == 0)
            {
                lblNone.Text = "No Student with the selected Skillset, " + ddlSearch.SelectedValue + ", is found";
                lblNone.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}