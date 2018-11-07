using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class AddParent
    {
        public int parentId { get; set; }
        public string parentname { get; set; }
        public string emailaddr { get; set; }
        public string password { get; set; }


        public int add()
        {
            //Read Connection String "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Insert into Database
            SqlCommand cmd = new SqlCommand("INSERT INTO Parent (ParentName, EmailAddr, Password) " +
                                             "OUTPUT INSERTED.ParentID" +
                                             " VALUES(@name, @email, @password)", conn);

            //Define the parameters used in SQL statement, value for each parameter
            // is retrived from respestive class's property. 
            cmd.Parameters.AddWithValue("@name", parentname);
            cmd.Parameters.AddWithValue("@email", emailaddr);
            cmd.Parameters.AddWithValue("@password", password);

            //A Connection to database must be opened before any operations made.
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //StaffID after executing the INSERT SQL statement
            int id = (int)cmd.ExecuteScalar();

            //A connection should be closed after operations.
            conn.Close();

            //Return id when no error occurs.
            return id;
        }

        public bool isEmailExist(string email)
        {
            string strConn = ConfigurationManager.ConnectionStrings
                             ["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand
                            ("SELECT * FROM Parent WHERE EmailAddr=@selectedEmail", conn);

            cmd.Parameters.AddWithValue("selectedEmail", email);

            SqlDataAdapter daEmail = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            conn.Open();

            //Use DataAdapter to fetch data to a table "EmailDetails" in DataSet.
            daEmail.Fill(result, "EmailDetail");
            conn.Close();

            if(result.Tables["EmailDetail"].Rows.Count > 0)
            {
                return true; //The email given exists
            }
            else
            {
                return false; // The email given doesn not exist
            }
        }
        
    }


}