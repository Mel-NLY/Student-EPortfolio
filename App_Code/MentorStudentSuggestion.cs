using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WEBAssignmentCheckpoint1
{
    public class MentorStudentSuggestion
    {
        public int suggestionId { get; set; }
        public int mentorId { get; set; }
        public int studentId { get; set; }
        public string mentorName { get; set; }
        public string description { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a staff record
            SqlCommand cmd = new SqlCommand("SELECT * " +
                "FROM Suggestion s INNER JOIN Mentor m " +
                "ON s.MentorID = m.MentorID WHERE SuggestionID=@suggestionID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the branchNo property of the Branch class
            cmd.Parameters.AddWithValue("@suggestionID", suggestionId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daMentorSuggestion = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet MentorSuggestionresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "MentorSuggestionDetails" in DataSet
            daMentorSuggestion.Fill(MentorSuggestionresult, "MentorSuggestionDetails");

            //Close database connection
            conn.Close();

            if (MentorSuggestionresult.Tables["MentorSuggestionDetails"].Rows.Count > 0)
            {
                //Fill MentorSuggestion Object with values from the Dataset
                DataTable table = MentorSuggestionresult.Tables["MentorSuggestionDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["SuggestionID"]))
                {
                    suggestionId = Convert.ToInt32(table.Rows[0]["SuggestionID"]);
                    mentorName = table.Rows[0]["Name"].ToString();
                    description = table.Rows[0]["Description"].ToString();
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }
    }
}