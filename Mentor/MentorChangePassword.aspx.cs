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
    public partial class MentorChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvCurrentPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Mentor WHERE EmailAddr = @enteredemail AND Password = @enteredpassword", conn);

            string loginID = (string)Session["LoginID"];
            cmd1.Parameters.AddWithValue("@enteredemail", loginID);
            cmd1.Parameters.AddWithValue("@enteredpassword", tbCurrentPassword.Text);

            SqlDataAdapter daPassword = new SqlDataAdapter(cmd1);
            DataSet passwordresult = new DataSet();

            conn.Open();
            cmd1.ExecuteNonQuery();
            //Use DataAdapter to fetch data to a table "Password Check" in DataSet
            daPassword.Fill(passwordresult, "Password Check");
            conn.Close();

            if (passwordresult.Tables["Password Check"].Rows.Count == 1)
            {
                args.IsValid = true; // No error
            }
            else
            {
                args.IsValid = false; // Raise error
            }
        }

        protected void btnCfmPassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Read connection string "Student_EPortfolio" from web.config file
                string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

                //Instantiate a SqlConnection object with the Connection String read
                SqlConnection conn = new SqlConnection(strConn);

                //Instantiate a SqlConnecton object, supply it with QL statement UPDATE and the connection object for connecting to the database
                SqlCommand cmd1 = new SqlCommand("UPDATE Mentor SET Password=@newpassword WHERE EmailAddr = @enteredemail", conn);
                string loginID = (string)Session["LoginID"];
                cmd1.Parameters.AddWithValue("@enteredemail", loginID);

                //Define the parameters used in SQL statement, value for each parameter is retrieved from respective class's property
                cmd1.Parameters.AddWithValue("@newpassword", tbCfmNewPassword.Text);

                //A connection to database must be opened before any operations made
                conn.Open();

                //ExecuteNonQuery is used for UPDATE and DELETE
                int count = cmd1.ExecuteNonQuery();
                //A connection should be closed after operations
                conn.Close();

                if (count > 0) //at least 1 row updated
                {
                    lblMessage.Text = "Password has been successfully updated"; //update successful
                }
                else
                {
                    lblMessage.Text = "Unable to update password, please try again"; //no update done
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}