using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WEBAssignmentCheckpoint1
{
    public class Suggestion
    {
        public int suggestionId { get; set; }
        public int mentorId { get; set; }
        public int studentId { get; set; }
        public string description { get; set; }
        public char status { get; set; }
        public DateTime dateCreated { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a staff record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Suggestion WHERE StudentID = @studentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the studentId property of the Student class
            cmd.Parameters.AddWithValue("@studentID", studentId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daSuggestion = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet Suggestionresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "SuggestionDetails" in DataSet
            daSuggestion.Fill(Suggestionresult, "SuggestionDetails");

            //Close database connection
            conn.Close();

            if (Suggestionresult.Tables["SuggestionDetails"].Rows.Count > 0)
            {
                //Fill Staff Object with values from the Dataset
                DataTable table = Suggestionresult.Tables["SuggestionDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Description"]))
                {
                    description = table.Rows[0]["Description"].ToString();
                    status = Convert.ToChar(table.Rows[0]["Status"]);
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }

        public int insertsuggestions()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Suggestion (MentorID,StudentID,Description,Status,DateCreated) OUTPUT INSERTED.SuggestionID " +
                "VALUES(@mentorid,@studentid,@description,@status,@datecreated)", conn);

            //Define the parameteres used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            cmd1.Parameters.AddWithValue("@mentorid", mentorId);
            cmd1.Parameters.AddWithValue("@studentid", studentId);
            cmd1.Parameters.AddWithValue("@description", description);
            cmd1.Parameters.AddWithValue("@status", status);
            cmd1.Parameters.AddWithValue("@datecreated", dateCreated);

            //A connection must be opened before any operations made.
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //StaffID after executing the INSERT SQL statement
            int id = (int)cmd1.ExecuteScalar();

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Return id when no error occurs.
            return id;
        }


        public void updateStatus()
        {
            // Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            // Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with an Update Sql statement 
            // and the connection object for connecting to the database
            SqlCommand cmd = new SqlCommand
                ("UPDATE Suggestion SET Status='Y' WHERE SuggestionID=@suggestionID", conn);

            // Define the parameters used in SQL statement, value for each parameter
            // is retrieved from respectibe class's property
            cmd.Parameters.AddWithValue("@suggestionID", suggestionId);

            // A connection to database must be opened before any operations made
            conn.Open();
            cmd.ExecuteNonQuery();

            // A connection should be closed after operations
            conn.Close();
        }
    }
}