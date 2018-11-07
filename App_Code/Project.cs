using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class Project
    {
        public int projectId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string projectPoster { get; set; }
        public string projectURL { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a Project record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project WHERE ProjectID = @ProjectID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the Projectid property of the Project class
            cmd.Parameters.AddWithValue("@ProjectID", projectId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daProject = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet Projectresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "ProjectDetails" in DataSet
            daProject.Fill(Projectresult, "ProjectDetails");

            //Close database connection
            conn.Close();

            if (Projectresult.Tables["ProjectDetails"].Rows.Count > 0)
            {
                //Fill Project Object with values from the Dataset
                DataTable table = Projectresult.Tables["ProjectDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Title"]))
                {
                    title = table.Rows[0]["Title"].ToString();
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }

        public int add()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT Sql statement 
            // which will return the auto-generated ProjectID after insertion, and the connection
            // object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("INSERT INTO Project (Title, Description, ProjectPoster, ProjectURL) " +
                "OUTPUT INSERTED.ProjectID " +
                "VALUES(@title, @description, @projectposter, @projecturl)", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@projectposter", projectPoster);
            cmd.Parameters.AddWithValue("@projecturl", projectURL);

            // A connection to database must be opened before any operations made
            conn.Open();

            // ExecuteScalar is used to retrieve the auto-generated 
            // ProjectID after executing the INSERT SQL statement
            int id = (int)cmd.ExecuteScalar();

            // A connection should be closed after operations
            conn.Close();

            // Return id when no error occurs
            return id;
        }

        public void update()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCOnnecton object, supply it with SQL statement UPDATE and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand("UPDATE Project SET Title=@title, Description=@description, ProjectPoster=@projectposter, ProjectURL=@projecturl WHERE ProjectID = @projectid", conn);

            //Define the parameters used in SQL statement, value for each parameter is retrieved from respective class's property
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@projectposter", projectPoster);
            cmd.Parameters.AddWithValue("@projecturl", projectURL);
            cmd.Parameters.AddWithValue("@projectid", projectId);


            //A connection to database must be opened before any operations made
            conn.Open();

            //Execute command
            int count = cmd.ExecuteNonQuery();

            //A connection should be closed after operations
            conn.Close();
        }
    }
}