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
    public partial class Project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayProjectInfo();
            displayLeaderInfo();
            displayMemberInfo();
        }

        private void displayProjectInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project p " +
                "INNER JOIN ProjectMember pm " +
                "ON p.ProjectID = pm.ProjectID " +
                "WHERE p.ProjectID = @projectID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

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
                    imgViewPoster.ImageUrl = table.Rows[0]["ProjectPoster"].ToString();
                    lblViewProjName.Text = table.Rows[0]["Title"].ToString();
                    lblViewProjURL.Text = table.Rows[0]["ProjectURL"].ToString();
                    lblViewProjDesc.Text = table.Rows[0]["Description"].ToString();
                }
            }
        }

        private void displayLeaderInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Student " +
                "WHERE StudentID = " +
                "(SELECT StudentID " +
                "FROM ProjectMember " +
                "WHERE ProjectID = @projectID " +
                "AND Role = 'Leader')", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daLeader = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet leaderresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "LeaderDetails" in DataSet
            daLeader.Fill(leaderresult, "LeaderDetails");

            //Close database connection
            conn.Close();

            if (leaderresult.Tables["LeaderDetails"].Rows.Count > 0)
            {
                //Fill LeaderDetails Object with values from the Dataset
                DataTable table = leaderresult.Tables["LeaderDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                {
                    lblViewLeader.Text = table.Rows[0]["Name"].ToString();
                }
            }
        }

        private void displayMemberInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statements
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Student " +
                "WHERE StudentID IN " +
                "(SELECT StudentID " +
                "FROM ProjectMember " +
                "WHERE ProjectID = @projectID " +
                "AND Role = 'Member')", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daMember = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet memberresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "MemberDetails" in DataSet
            daMember.Fill(memberresult, "MemberDetails");

            //Close database connection
            conn.Close();

            if (memberresult.Tables["MemberDetails"].Rows.Count > 0)
            {
                //Fill MemberDetails Object with values from the Dataset
                DataTable table = memberresult.Tables["MemberDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                {
                    string members = "";

                    if (table.Rows.Count > 1)
                    {
                        for (int i = 0; i < table.Rows.Count - 1; i++)
                        {
                            members += table.Rows[i]["Name"].ToString() + ",";
                        }

                        int last = table.Rows.Count - 1;
                        members += table.Rows[last]["Name"].ToString();
                    }

                    else
                    {
                        lblViewMember.Text = table.Rows[0]["Name"].ToString();
                    }

                    lblViewMember.Text = members;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/ProjectList.aspx");
        }
    }
}