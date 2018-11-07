using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public class Student
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string emailAddr { get; set; }
        public int mentorId { get; set; }
        public string photo { get; set; }

        public int add()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("INSERT INTO Student (Name, Course, EmailAddr, MentorID) " + "OUTPUT INSERTED.StudentID " + "VALUES(@name, @course, @emailAddr, @mentorId)", conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@course", course);
            cmd.Parameters.AddWithValue("@emailAddr", emailAddr);
            cmd.Parameters.AddWithValue("@mentorId", mentorId);

            conn.Open();

            int id = (int)cmd.ExecuteScalar();

            conn.Close();

            return id;
        }

        public int insertPhoto()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("UPDATE Student SET Photo=@photo WHERE StudentID=@selectedStudentID", conn);

            cmd.Parameters.AddWithValue("@photo", photo);

            cmd.Parameters.AddWithValue("@selectedStudentID", studentId);

            conn.Open();

            int count = cmd.ExecuteNonQuery();

            conn.Close();

            if (count > 0)
                return 0;
            else
                return 1;
        }

        public bool isEmailExist(string emailAddr)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Student WHERE EmailAddr=@selectedEmail", conn);

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