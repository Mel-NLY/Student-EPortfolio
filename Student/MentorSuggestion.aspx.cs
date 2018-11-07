using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public partial class MentorSuggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayMentorSuggestion();
            }
        }

        private void displayMentorSuggestion()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement 
            SqlCommand cmd = new SqlCommand("SELECT Name, Status, Description, SuggestionID " +
                "FROM Suggestion s INNER JOIN Mentor m " +
                "ON s.MentorID = m.MentorID WHERE StudentID=@studentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the session StudentID
            cmd.Parameters.AddWithValue("@studentID", Session["StudentID"]);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daSuggestion = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet result = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "MentorSuggestions" in DataSet
            daSuggestion.Fill(result, "MentorSuggestions");

            //Close database connection
            conn.Close();

            //Display results in GridView
            gvMentorSuggestion.DataSource = result.Tables["MentorSuggestions"];
            gvMentorSuggestion.DataBind();
        }

        protected void gvMentorSuggestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                // Retrieve the row index stored in the CommandArgument property
                int i = Convert.ToInt32(e.CommandArgument);

                // Detect the txtTelNo textbox control in the row of gridview
                // Use "FindControl" method to obtain references to row's controls
                char status = Convert.ToChar(gvMentorSuggestion.Rows[i].Cells[2].Text);

                // Get the Branch No from the second column
                string description = (gvMentorSuggestion.Rows[i].Cells[1].Text).ToString();

                //Read connection string "Student_EPortfolio" from web.config file
                string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

                //Instantiate a SqlConnection object with the Connection String read
                SqlConnection conn = new SqlConnection(strConn);

                //Instantiate a SqlCommand object, supply it with a SELECT SQL statement 
                SqlCommand cmd = new SqlCommand("SELECT SuggestionID FROM Suggestion WHERE Description=@description", conn);

                //Define the paramter used in SQL statement, value for the parameter is retrieved
                cmd.Parameters.AddWithValue("@description", description);

                //Open a database connection
                conn.Open();

                //Execute query
                int suggestionid = (int)cmd.ExecuteScalar();

                //Close database connection
                conn.Close();

                //Create object with MentorStudentSuggestion Class
                Suggestion objSuggestion = new Suggestion();
                
                //Insert suggestionID value
                objSuggestion.suggestionId = suggestionid;

                //Get values from class - updateStatus() and
                //Display values 
                objSuggestion.updateStatus();

                displayMentorSuggestion();
            }
        }
    }
}