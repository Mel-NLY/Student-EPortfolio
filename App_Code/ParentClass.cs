using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class ParentClass
    {
        public int parentId { get; set; }
        public string parentName { get; set; }
        public string emailAddr { get; set; }
        public string password { get; set; }
        public string child { get; set; }
        public string status { get; set; }
        public DateTime retrieveDateTime { get; set; }
        public int viewingRequestID { get; set; }
        public string name { get; set; }
        //public int studentID { get; set; }

        //public int messageID { get; set; }
        public int fromID { get; set; }
        public int toID { get; set; }
        public DateTime datePosted { get; set; }
        public string title { get; set; }
        public string text { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a parent record
            SqlCommand cmd = new SqlCommand("SELECT * FROM Parent WHERE ParentID = @parentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the parentid property of the parent class
            cmd.Parameters.AddWithValue("@parentID", parentId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daparent = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet parentresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "parentDetails" in DataSet
            daparent.Fill(parentresult, "parentDetails");

            //Close database connection
            conn.Close();

            if (parentresult.Tables["parentDetails"].Rows.Count > 0)
            {
                //Fill parent Object with values from the Dataset
                DataTable table = parentresult.Tables["parentDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["ParentName"]))
                {
                    parentName = table.Rows[0]["ParentName"].ToString();
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }

        public int add()
        {
            //Read Connection String "Student_EPortfolio" from web.config file.
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortFolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Insert into Database
            SqlCommand cmd = new SqlCommand("INSERT INTO Parent (ParentName, EmailAddr, Password) " +
                                             "OUTPUT INSERTED.ParentID " +
                                             "VALUES(@name, @email, @password)", conn);

            //Define the parameters used in SQL statement, value for each parameter
            // is retrived from respestive class's property.
            cmd.Parameters.AddWithValue("@name", parentName);
            cmd.Parameters.AddWithValue("@email", emailAddr);
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

        public int insertData()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("INSERT INTO ViewingRequest (ParentID, StudentName, Status, DateCreated) " +
                "OUTPUT inserted.ViewingRequestID VALUES(@parentID, @studentName,@status, @dateCreated)", conn);
            //Insert Data into Database 

            cmd1.Parameters.AddWithValue("@parentID", parentId);
            cmd1.Parameters.AddWithValue("@studentName", child);
            //cmd1.Parameters.AddWithValue("@studentID", studentID);
            cmd1.Parameters.AddWithValue("@status", status);
            cmd1.Parameters.AddWithValue("@dateCreated", retrieveDateTime);
            //Add Values into Table

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter childName = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            childName.Fill(result, "Student");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            return parentId;
        }

        public void insertMessage()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Message (FromID, ToID, DateTimePosted, Title, Text) " +
                "OUTPUT inserted.MessageID VALUES(@fromID, (Select MentorID FROM Mentor WHERE MentorID = @toID), @datePosted, @title, @text)", conn);
            //Insert Data into Database 

            cmd1.Parameters.AddWithValue("@fromID", fromID);
            cmd1.Parameters.AddWithValue("@toID", toID);
            cmd1.Parameters.AddWithValue("@datePosted", datePosted);
            cmd1.Parameters.AddWithValue("@title", title);
            cmd1.Parameters.AddWithValue("@text", text);


            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter Message = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            Message.Fill(result, "Mentor");

            //A connection should always be closed whether error occurs or not
            conn.Close();
        }

        public void postMessage()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Message (FromID, ToID, DateTimePosted, Title, Text) " +
                "OUTPUT inserted.MessageID VALUES(@fromID,@toID, @datePosted, @title, @text)", conn);
            //Insert Data into Database 
            
            cmd1.Parameters.AddWithValue("@formID", fromID);
            cmd1.Parameters.AddWithValue("@toID", toID);
            cmd1.Parameters.AddWithValue("@datePosted", datePosted);
            cmd1.Parameters.AddWithValue("@title", title);
            cmd1.Parameters.AddWithValue("@text", text);
            //Add Values into Table

            /*Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter message = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();
            */ //Only For Select SQL QueryString

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            cmd1.ExecuteNonQuery();

            //A connection should always be closed whether error occurs or not
            conn.Close();
            
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

            //Open a Database Connection
            conn.Open();

            //Use DataAdapter to fetch data to a table "EmailDetails" in DataSet.
            daEmail.Fill(result, "EmailDetails");

            //Close Database Connection
            conn.Close();

            if (result.Tables["EmailDetails"].Rows.Count > 0)
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