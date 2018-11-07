using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.Parent
{
    public partial class SubmitViewingRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ParentName"] != null)
            {
                lblParent.Text = (string)Session["ParentName"];
            }
        }

        private void retrieveChildName()
        {
            string child = txtChild.Text; //TextBox: txtChild

            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT Student.StudentID FROM Student INNER JOIN " +
                "ViewingRequest ON Student.StudentID = ViewingRequest.StudentID WHERE Student.Name = @Name ", conn);

            cmd1.Parameters.AddWithValue("@Name", child);

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

            //Specify GridView to get data from table "ProjectDetails"
            //in DataSet "result'
            //gvStudent.DataSource = result.Tables["ProjectDetails"];

            //Display the list of data in GridView
            //gvStudent.DataBind();

            if (result.Tables["Student"].Rows.Count > 0)
            {
                // Save the login id and time in the Session
                //Session["LoginID"] = loginID;
                //Session["LoggedInTime"] = DateTime.Now.ToString();
                Session["StudentID"] = result.Tables["Student"].Rows[0]["StudentID"];

                //Means Student Exist Have to insert SQL Statement


                //Redirect user to Main.aspx page
                Response.Redirect("ViewChildPortfolio.aspx");
            }
            else
            {
                lblError.Text = "Student Doesn't Exist";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Student", conn);

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

            if (chkCorrect.Checked && result.Tables["Student"].Rows.Count > 0)
            {
                ParentClass objparent = new ParentClass();

                objparent.viewingRequestID = Convert.ToInt32(Request.QueryString["ViewingRequestID"]); 
                //Request.QueryString to retrieve Value
                objparent.parentId = Convert.ToInt32(Session["ParentID"]);
                lblParent.Text = Session["ParentName"].ToString();
                objparent.child = txtChild.Text;
                //objparent.studentID = Convert.ToInt32(Session["StudentID"]);
                objparent.status = "P";
                objparent.retrieveDateTime = DateTime.Now;
                int id = objparent.insertData();

                lblInfo.Visible = false;
                //If the Information is Valid, i didnt click the checkbox it must appear to be false

                retrieveChildName(); //Retrieve the above method and RUN
            }
            else
            {
                lblInfo.Text = "Please Verify if the Information is Valid.";
                lblInfo.Visible = true;
            }

            
        }
       
    }
}