using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public partial class ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayProjectList();
            }
        }

        private void displayProjectList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement
            SqlCommand cmd = new SqlCommand("SELECT ProjectID, Title, Description FROM Project " +
                "WHERE ProjectID IN " +
                "(SELECT ProjectID FROM ProjectMember " +
                "WHERE StudentID=@studentID)", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the session StudentID
            cmd.Parameters.AddWithValue("@studentID", Session["StudentID"]);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daProjectList = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet ProjectListresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "ProjectListDetails" in DataSet
            daProjectList.Fill(ProjectListresult, "ProjectListDetails");

            //Close database connection
            conn.Close();

            //Display results in GridView
            gvProjectList.DataSource = ProjectListresult.Tables["ProjectListDetails"];
            gvProjectList.DataBind();
        }

    }
}