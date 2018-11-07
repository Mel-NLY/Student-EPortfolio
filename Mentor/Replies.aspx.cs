using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WEBAssignmentCheckpoint1.Mentor
{
    public partial class Replies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["LoginID"] != null)
            {
                //Create a new Mentor, Reply, Parent and ViewingRequest object
                MentorClass objMentor = new MentorClass();
                MessageClass objMessage = new MessageClass();
                ParentClass objParent = new ParentClass();
                ViewingRequest objViewingRequest = new ViewingRequest();

                //Read Mentor, Reply, Parent and ViewingRequest from query string
                objMentor.mentorId = Convert.ToInt32(Session["MentorId"]);
                objMessage.messageId = Convert.ToInt32(Request.QueryString["MessageId"]);
                objParent.parentId = Convert.ToInt32(Request.QueryString["ParentId"]);
                objViewingRequest.parentId = Convert.ToInt32(Request.QueryString["ParentId"]);

                //Load Mentor, Reply, Parent and ViewingRequest information to controls
                int mentorerrorCode = objMentor.getDetails();
                int messageerrorCode = objMessage.getDetails();
                int parenterrorCode = objParent.getDetails();
                int viewingrequesterrorCode = objViewingRequest.getDetails();
                if (mentorerrorCode == 0)
                {
                    lblMentorName.Text = objMentor.mentorname;
                }
                else if (mentorerrorCode == -2)
                {
                    lblMentorName.Text = "Unable to retrieve Mentor details for ID " + objMentor.mentorId;
                    lblMentorName.ForeColor = System.Drawing.Color.Red;
                }
                if (messageerrorCode == 0)
                {
                    lblMessage.Text = objMessage.text;
                    lblOriginalMessage.Text = objMessage.text;
                }
                else if (messageerrorCode == -2)
                {
                    lblMessage.Text = "Unable to retrieve Message details for ID " + objMessage.messageId;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                if (parenterrorCode == 0)
                {
                    lblParentName.Text = objParent.parentName;
                    lblOriginalParent.Text = objParent.parentName;
                }
                else if (parenterrorCode == -2)
                {
                    lblParentName.Text = "Unable to retrieve Parent details for ID " + objParent.parentId;
                    lblParentName.ForeColor = System.Drawing.Color.Red;
                }
                if (viewingrequesterrorCode == 0)
                {
                    lblStudent.Text = objViewingRequest.studentName;
                }
                else if (viewingrequesterrorCode == -2)
                {
                    lblStudent.Text = "Unable to retrieve Student details for ID " + objViewingRequest.parentId;
                    lblStudent.ForeColor = System.Drawing.Color.Red;
                }
                displayReplyList();
            }
        }

        private void displayReplyList()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT Parent.ParentName, Mentor.Name AS 'MentorName', Reply.Text, Reply.DateTimePosted FROM Reply LEFT OUTER JOIN Mentor ON Mentor.MentorID = Reply.MentorID LEFT OUTER JOIN Parent ON Parent.ParentID = Reply.ParentID WHERE MessageID = @messageid", conn);

            //Instantiate a Datadapter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daMessage = new SqlDataAdapter(cmd1);
            cmd1.Parameters.AddWithValue("@messageid", Convert.ToInt32(Request.QueryString["MessageId"]));

            //Create a Dataset object to contain the records retrieved from database
            DataSet replyresult = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "Parent Replies" in DataSet
            //DataSet "replyresult" will store the result of the SELECT operation
            daMessage.Fill(replyresult, "Parent Replies");
            cmd1.ExecuteNonQuery();

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "Parent Replies"
            //in DataSet "replyresult'
            gvReply.DataSource = replyresult.Tables["Parent Replies"];

            //Display the list of data in GridView
            gvReply.DataBind();
        }

    protected void btnSubmitReply_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Create a new object from the Replies CLass
                RepliesClass objReplies = new RepliesClass();
                objReplies.messageId = Convert.ToInt32(Request.QueryString["MessageId"]);
                objReplies.mentorId = Convert.ToInt32(Session["MentorId"]);
                objReplies.dateTimePosted = DateTime.Now;
                objReplies.text = tbReply.Text;

                //Call the add method to insert the staff record to database
                int newreplyid = objReplies.insertreplies();
                lblSuccessful.Text = "Reply successfully sent!";
                lblSuccessful.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}