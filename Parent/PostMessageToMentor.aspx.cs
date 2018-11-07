using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.Parent
{
    public partial class PostMessageToMentor : System.Web.UI.Page
    {
        DataSet result = new DataSet();
        int mentor;
        protected void Page_Load(object sender, EventArgs e)
        {
            retrieveMentor();
        }

        private void retrieveMentor()
        {
            //string message = txtMessage.Text; //TextBox: txtChild

            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT m.MentorID, m.Name FROM ViewingRequest vr INNER JOIN Student s ON vr.StudentID = s.StudentID " +
                "INNER JOIN Mentor m ON s.MentorID = m.MentorID WHERE vr.ParentID = @parentID ", conn);

            int parentID = Convert.ToInt32(Session["ParentID"].ToString());

            cmd1.Parameters.AddWithValue("@parentID", parentID);

            //Instantiate a Datadpter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter mentorName = new SqlDataAdapter(cmd1);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "ProjectDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            mentorName.Fill(result, "Mentor");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            gvmentor.DataSource = result.Tables["Mentor"];

            //Display the list of data in GridView
            gvmentor.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ParentClass objMentor = new ParentClass();

            objMentor.fromID = Convert.ToInt32(Session["ParentID"].ToString());
            objMentor.toID = Convert.ToInt32(gvmentor.SelectedValue); //Convert.ToInt32(result.Tables["Mentor"].Rows[mentor]["MentorID"]);
            objMentor.datePosted = DateTime.Now;
            objMentor.title = txtTitle.Text;
            objMentor.text = txtMessage.Text;

            objMentor.insertMessage();

            lblAlert.Text = "*Your Message had been Sent";
        }

        protected void gvmentor_SelectedIndexChanged(object sender, EventArgs e)
        {
            mentor = Convert.ToInt32(gvmentor.SelectedValue);
            //lblMentor.Text = result.Tables["Mentor"].Rows[gvmentor.SelectedIndex]["Name"].ToString();
        }
    }
}