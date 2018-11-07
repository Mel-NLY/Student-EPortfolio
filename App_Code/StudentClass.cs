using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class StudentClass
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public string achievement { get; set; }
        public string externalLink{ get; set; }
        public string emailAddr { get; set; }
        public string password { get; set; }
        public char status { get; set; }
        public int mentorId { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a Student record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE StudentID = @studentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the Studentid property of the Student class
            cmd.Parameters.AddWithValue("@studentID", studentId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet Studentresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "StudentDetails" in DataSet
            daStudent.Fill(Studentresult, "StudentDetails");

            //Close database connection
            conn.Close();

            if (Studentresult.Tables["StudentDetails"].Rows.Count > 0)
            {
                //Fill Student Object with values from the Dataset
                DataTable table = Studentresult.Tables["StudentDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["StudentID"]))
                {
                    name = table.Rows[0]["Name"].ToString();
                    description = table.Rows[0]["Description"].ToString();
                    photo = table.Rows[0]["Photo"].ToString();
                    status = Convert.ToChar(table.Rows[0]["Status"]);
                    achievement = table.Rows[0]["Achievement"].ToString();
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }

        public int updateprofilestatus()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCOnnecton object, supply it with SQL statement UPDATE and the connection object for connecting to the database
            SqlCommand cmd1 = new SqlCommand("UPDATE Student SET Status=@status WHERE StudentID = @selectedStudentID", conn);

            //Define the parameters used in SQL statement, value for each parameter is retrieved from respective class's property
            cmd1.Parameters.AddWithValue("@status", status);
            cmd1.Parameters.AddWithValue("@selectedStudentID", studentId);

            //A connection to database must be opened before any operations made
            conn.Open();

            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd1.ExecuteNonQuery();
            //A connection should be closed after operations
            conn.Close();

            if (count > 0) //at least 1 row updated
                return 0; //update successful
            else
                return -2;//no update done
        }

        public void updateProfile()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an Update Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("UPDATE Student SET Photo=@photo, Description=@description, Achievement=@achievement WHERE StudentID=@StudentID", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@photo", photo);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@achievement", achievement);
            cmd.Parameters.AddWithValue("@StudentID", studentId);

            // A connection to database must be opened before any operations made
            conn.Open();
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }
    }
}