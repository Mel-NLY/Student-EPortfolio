using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.Mentor
{
    public partial class ParentMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayMessageList();
        }
        private void displayMessageList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT m.MessageID AS 'MessageID', ParentName, m.DateTimePosted, MAX(r.DateTimePosted) AS 'DateTimeUpdated' FROM Parent p INNER JOIN Message m ON m.FromID = p.ParentID INNER JOIN Reply r ON m.MessageID = r.MessageID INNER JOIN Mentor me ON m.ToID = me.MentorID WHERE me.EmailAddr = @loggedmentor GROUP BY m.MessageID, ParentName, m.DateTimePosted", conn);

            //Instantiate a Datadapter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daMessage = new SqlDataAdapter(cmd1);
            string loggedemail = (string)Session["LoginID"];
            cmd1.Parameters.AddWithValue("@loggedmentor", loggedemail);

            //Create a Dataset object to contain the records retrieved from database
            DataSet messageresult = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "Parent Messages" in DataSet
            //DataSet "messageresult" will store the result of the SELECT operation
            daMessage.Fill(messageresult, "Parent Messages");
            cmd1.ExecuteNonQuery();

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "Parent Messages"
            //in DataSet "result'
            gvParentMessage.DataSource = messageresult.Tables["Parent Messages"];

            //Display the list of data in GridView
            gvParentMessage.DataBind();
        }
    }
}