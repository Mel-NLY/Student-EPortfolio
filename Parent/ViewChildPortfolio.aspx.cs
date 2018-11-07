using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.Parent
{
    public partial class ViewChildPortfolio : System.Web.UI.Page
    {

        //Dataset Variable
        DataSet result = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            displayDropDownList();
            
        }

        private void displayDropDownList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);
            result = new DataSet(); //Create New Result
            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT Student.* FROM Student INNER JOIN ViewingRequest " +
                "ON Student.StudentID = ViewingRequest.StudentID " +
                "WHERE ViewingRequest.Status = 'A' AND ViewingRequest.ParentID = @parentID", conn);

            cmd1.Parameters.AddWithValue("@parentID", Session["ParentID"]);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter sportfolio = new SqlDataAdapter(cmd1);


            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            sportfolio.Fill(result, "Student");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            //gvStudent.DataSource = result.Tables["Student"];
            //Display the list of data in GridView
            //gvStudent.DataBind();
            gvSelectStudent.DataSource = result.Tables["Student"];
            gvSelectStudent.DataBind();
        }

        private void viewProject(int StudentID)
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT Project.* FROM ProjectMember INNER JOIN Project " +
                "ON ProjectMember.ProjectID = Project.ProjectID WHERE ProjectMember.StudentID = @studentID", conn);

            cmd1.Parameters.AddWithValue("@studentID", StudentID);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter sportfolio = new SqlDataAdapter(cmd1);

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            sportfolio.Fill(result, "Project");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            gvProject.DataSource = result.Tables["Project"];

            //Display the list of data in GridView
            gvProject.DataBind();
        }

     

        private void displayStudentProfile(int studID)
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);
            result = new DataSet(); //Create New Result
            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Student WHERE StudentID = @studentID", conn);

            cmd1.Parameters.AddWithValue("@studentID", studID);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter sportfolio = new SqlDataAdapter(cmd1);


            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            sportfolio.Fill(result, "StudentProfile");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            //gvStudent.DataSource = result.Tables["StudentProfile"];

            //Display the list of data in GridView
            //gvStudent.DataBind();

            imgView.ImageUrl = "~/Images/Student/" + result.Tables["StudentProfile"].Rows[0]["Photo"].ToString();
            lblName.Text = result.Tables["StudentProfile"].Rows[0]["Name"].ToString();
            lblCourse.Text = result.Tables["StudentProfile"].Rows[0]["Course"].ToString();
            lblDescription.Text = result.Tables["StudentProfile"].Rows[0]["Description"].ToString();
            lblAchievement.Text = result.Tables["StudentProfile"].Rows[0]["Achievement"].ToString();
            lblLink.Text = result.Tables["StudentProfile"].Rows[0]["ExternalLink"].ToString();

            //ddlStudent.DataSource = result.Tables["Student"];
            //ddlStudent.DataTextField = "Name"; //Select the string From the Column
            //ddlStudent.DataValueField = "StudentID"; //Column that is selected and return from the column
            //ddlStudent.DataBind(); //Bind Every Single Data
            //ddlStudent.Items.Insert(0, "---Select Child---");
        }

        protected void gvSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = gvSelectStudent.SelectedIndex;
            int studID = Convert.ToInt32(result.Tables["Student"].Rows[selectedRow]["StudentID"].ToString());
            //.ToString "StudentID" change value to String
            //Convert.Toint32 to integer again
            displayStudentProfile(studID);
            viewProject(studID);
        }
    }
}