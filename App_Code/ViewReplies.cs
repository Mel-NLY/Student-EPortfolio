using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class ViewReplies
    {
        //Properties
        public int parentID { get; set; }
        public string text { get; set; }
        public DateTime datetimeposted { get; set; }


        public int getReplies (ref DataSet result)
        {
            //Read connection string "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Retrieve Object from Database. Using a SQL Command
            SqlCommand cmd = new SqlCommand("SELECT Reply.MentorID, ParentID, DateTimePosted, Text AS 'Message' FROM Reply INNER JOIN Mentor ON Mentor.MentorID = Reply.MentorID", conn);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //Object created as parameter.
            SqlDataAdapter daReply = new SqlDataAdapter(cmd);

            //Open a Database Connection
            conn.Open();

            //Use DataAdapter to fetch data to a table "Message" in DataSet
            daReply.Fill(result, "");

            //Close Database Connection
            conn.Close();
            
            //Return 0 if no error occurs
            return 0;


        }
    }
}