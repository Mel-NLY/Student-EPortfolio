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
    public partial class PendingStudentPortfolios_Project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create a new Student object
            StudentClass objStudent = new StudentClass();

            //Read Student from query string
            objStudent.studentId = Convert.ToInt32(Request.QueryString["StudentId"]);

            //Load Student information to controls
            int studenterrorCode = objStudent.getDetails();
            if (studenterrorCode == 0)
            {
                lblName.Text = objStudent.name;
                lblNameBar.Text = objStudent.name;
            }
            else if (studenterrorCode == -2)
            {
                lblName.Text = "Unable to retrieve Student details for ID " + objStudent.studentId;
                lblName.ForeColor = System.Drawing.Color.Red;
            }

            displayProjectList();
        }

        private void displayProjectList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Project p INNER JOIN ProjectMember pm ON p.ProjectID = pm.ProjectID INNER JOIN Student s ON pm.StudentID = s.StudentID WHERE pm.StudentID = @selectedstudentid", conn);

            cmd1.Parameters.AddWithValue("@selectedstudentid", Convert.ToString(Request.QueryString["StudentId"]));

            //Instantiate a Datadapter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daProject = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daProject.Fill(result, "ProjectDetails");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            gvProjects.DataSource = result.Tables["ProjectDetails"];

            //Display the list of data in GridView
            gvProjects.DataBind();

            if (result.Tables["ProjectDetails"].Rows.Count == 0)
            {
                lblNone.Text = "No projects found";
                lblNone.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}