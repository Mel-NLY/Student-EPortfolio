using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class ProjectMember
    {
        public int projectId { get; set; }
        public int studentId { get; set; }
        public string role { get; set; }
        public string reflection { get; set; }


        public void add()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("INSERT INTO ProjectMember (ProjectID, StudentID, Role, Reflection) " +
                "VALUES(@projectId, @studentId, @role, @reflection)", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@reflection", reflection);

            // A connection to database must be opened before any operations made
            conn.Open();

            // Execute query
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }

        public void deleteMember()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("DELETE FROM ProjectMember WHERE Role = 'Member' AND ProjectID=@projectid", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@projectid", projectId);

            // A connection to database must be opened before any operations made
            conn.Open();

            // Execute query
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }

        public void updateReflection()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("UPDATE ProjectMember SET Reflection=@reflection WHERE ProjectID=@projectid AND StudentID=@studentid", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@reflection", reflection);
            cmd.Parameters.AddWithValue("@projectid", projectId);
            cmd.Parameters.AddWithValue("@studentid", studentId);

            // A connection to database must be opened before any operations made
            conn.Open();

            // Execute query
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }
    }
}