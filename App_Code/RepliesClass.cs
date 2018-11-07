using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class RepliesClass
    {
        public int replyId { get; set; }
        public int messageId { get; set; }
        public int mentorId { get; set; }
        public int parentId { get; set; } 
        public DateTime dateTimePosted { get; set; }
        public string text { get; set; }

        public int insertreplies()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Reply (MessageID,MentorID,ParentID,DateTimePosted,Text) OUTPUT INSERTED.ReplyID VALUES(@messageid,@mentorid,NULL,@datetimeposted,@messagetext)", conn);

            //Define the parameteres used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            cmd1.Parameters.AddWithValue("@messageid", messageId);
            cmd1.Parameters.AddWithValue("@mentorid", mentorId);
            cmd1.Parameters.AddWithValue("@datetimeposted", dateTimePosted);
            cmd1.Parameters.AddWithValue("@messagetext", text);

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
    }
}