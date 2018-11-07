using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class MessageClass
    {
        public int messageId { get; set; }
        public int fromId { get; set; }
        public int toId { get; set; }
        public DateTime dateTimePosted { get; set; }
        public string title { get; set; }
        public string text { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a message record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Message WHERE MessageID = @messageID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the messageid property of the Message class
            cmd.Parameters.AddWithValue("@messageID", messageId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daMessage = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet messageresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "MessageDetails" in DataSet
            daMessage.Fill(messageresult, "MessageDetails");

            //Close database connection
            conn.Close();

            if (messageresult.Tables["MessageDetails"].Rows.Count > 0)
            {
                //Fill Message Object with values from the Dataset
                DataTable table = messageresult.Tables["MessageDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Text"]))
                {
                    text = table.Rows[0]["Text"].ToString();
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