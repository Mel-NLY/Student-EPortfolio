using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WEBAssignmentCheckpoint1.Student
{
    public partial class ProjectReflection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayProjectInfo();
            }
        }

        private void displayProjectInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project p " +
                "INNER JOIN ProjectMember pm " +
                "ON p.ProjectID = pm.ProjectID " +
                "WHERE p.ProjectID = @projectID AND StudentID=@studentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);
            int studentID = Convert.ToInt32(Session["StudentID"]);
            cmd.Parameters.AddWithValue("@studentID", studentID);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daProject = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet projectresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "ProjectDetails" in DataSet
            daProject.Fill(projectresult, "ProjectDetails");

            //Close database connection
            conn.Close();

            if (projectresult.Tables["ProjectDetails"].Rows.Count > 0)
            {
                //Fill ProjectDetails Object with values from the Dataset
                DataTable table = projectresult.Tables["ProjectDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["ProjectID"]))
                {
                    lblProjectName.Text = table.Rows[0]["Title"].ToString();
                    txtReflection.Text = table.Rows[0]["Reflection"].ToString();
                }
            }
        }

        protected void btnUpdateReflection_Click(object sender, EventArgs e)
        {
            // Create a new object from the ProjectMember Class
            ProjectMember objProjMem = new ProjectMember();

            // Pass data to the properties of the ProjectMember object
            objProjMem.reflection = txtReflection.Text;
            objProjMem.projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            objProjMem.studentId = (int)Session["StudentID"];

            // Call the add method to insert the projectMember record to database
            objProjMem.updateReflection();

            // Pass as query string
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            string querystring = "~/Student/Project.aspx?projectid=" + projectId;
            Response.Redirect(querystring);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/ProjectList.aspx");
        }
    }
}