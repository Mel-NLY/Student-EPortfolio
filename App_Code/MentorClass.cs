using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class MentorClass
    {
        public int mentorId { get; set; }
        public string mentorname { get; set; }
        public string emailaddr { get; set; }
        public string password { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a staff record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mentor WHERE MentorID = @mentorID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the branchNo property of the Branch class
            cmd.Parameters.AddWithValue("@mentorID", mentorId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daMentor = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet mentorresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "MentorDetails" in DataSet
            daMentor.Fill(mentorresult, "MentorDetails");

            //Close database connection
            conn.Close();

            if (mentorresult.Tables["MentorDetails"].Rows.Count > 0)
            {
                //Fill Staff Object with values from the DatasET
                DataTable table = mentorresult.Tables["MentorDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                {
                    mentorname = table.Rows[0]["Name"].ToString();
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