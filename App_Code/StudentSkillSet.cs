using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class StudentSkillSet
    {
        public int studentId { get; set; }
        public int skillsetId { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a StudentSkillSet record
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentSkillSet WHERE StudentID = @studentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the Studentid property of the Student class
            cmd.Parameters.AddWithValue("@studentID", studentId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daStudentSkillSet = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet StudentSkillSetresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "StudentDetails" in DataSet
            daStudentSkillSet.Fill(StudentSkillSetresult, "StudentSkillSetDetails");

            //Close database connection
            conn.Close();

            if (StudentSkillSetresult.Tables["StudentSkillSetDetails"].Rows.Count > 0)
            {
                //Fill StudentSkillSet Object with values from the Dataset
                DataTable table = StudentSkillSetresult.Tables["StudentSkillSetDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["StudentID"]))
                {
                    skillsetId = Convert.ToInt32(table.Rows[0]["SkillSetID"]);
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }

        public void add()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an INSERT Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("INSERT INTO StudentSkillSet (StudentID, SkillSetID) " +
                "VALUES(@studentid, @skillsetid)", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@studentid", studentId);
            cmd.Parameters.AddWithValue("@skillsetid", skillsetId);
            
            // A connection to database must be opened before any operations made
            conn.Open();

            // ExecuteScalar is used to retrieve the auto-generated 
            // ProjectID after executing the INSERT SQL statement
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }

        public void delete()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with a DELETE Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("DELETE FROM StudentSkillSet WHERE StudentID=@studentid", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@studentid", studentId);

            // A connection to database must be opened before any operations made
            conn.Open();

            // ExecuteScalar is used to retrieve the auto-generated 
            // ProjectID after executing the INSERT SQL statement
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }
    }
}