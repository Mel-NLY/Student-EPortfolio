using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public class Mentor
    {
        public int mentorId { get; set; }
        public string name { get; set; }
        public string emailAddr { get; set; }

        public int add()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("INSERT INTO Mentor (Name, EmailAddr)" + "OUTPUT INSERTED.MentorID " + "VALUES(@name, @emailAddr)", conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@emailAddr", emailAddr);

            conn.Open();

            int id = (int)cmd.ExecuteScalar();

            conn.Close();

            return id;
        }

        public bool isEmailExist(string emailAddr)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Mentor WHERE EmailAddr=@selectedEmail", conn);

            cmd.Parameters.AddWithValue("@selectedEmail", emailAddr);

            SqlDataAdapter daEmail = new SqlDataAdapter(cmd);

            DataSet result = new DataSet();

            conn.Open();

            daEmail.Fill(result, "EmailDetails");

            conn.Close();

            if (result.Tables["EmailDetails"].Rows.Count > 0)
                return true; //The email given exists
            else
                return false; //The email given does not exist
        }
    }
}