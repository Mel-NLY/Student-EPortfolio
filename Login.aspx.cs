using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Read inputs from textboxes
            string loginID = tbEmail.Text.ToLower(); //Textbox: txtLoginID
            string password = tbPassword.Text; //Textbox: txtPassword

            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn.ToString());

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Mentor WHERE EmailAddr=@enteredemail AND Password=@enteredpassword", conn);

            cmd1.Parameters.AddWithValue("@enteredemail", loginID);
            cmd1.Parameters.AddWithValue("@enteredpassword", password);

            SqlDataAdapter daLoginID = new SqlDataAdapter(cmd1);
            DataSet loginidresult = new DataSet();

            conn.Open();
            cmd1.ExecuteNonQuery();
            daLoginID.Fill(loginidresult, "MentorLoginIDCheck");
            conn.Close();
            
            if (loginidresult.Tables["MentorLoginIDCheck"].Rows.Count == 1)
            {
                // Save the login id and time in the Session
                Session["LoginID"] = loginID;
                Session["LoggedInTime"] = DateTime.Now.ToString();
                Session["MentorID"] = loginidresult.Tables["MentorLoginIDCheck"].Rows[0]["MentorID"];

                //Redirect user to Main.aspx page
                Response.Redirect("~/Mentor/MentorHomePage.aspx");
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Student WHERE EmailAddr=@enteredemail AND Password=@enteredpassword", conn);

                cmd2.Parameters.AddWithValue("@enteredemail", loginID);
                cmd2.Parameters.AddWithValue("@enteredpassword", password);

                SqlDataAdapter daStudentLoginID = new SqlDataAdapter(cmd2);
                DataSet studentloginidresult = new DataSet();

                conn.Open();
                cmd2.ExecuteNonQuery();
                daStudentLoginID.Fill(studentloginidresult, "StudentLoginIDCheck");
                conn.Close();

                if (studentloginidresult.Tables["StudentLoginIDCheck"].Rows.Count == 1)
                {
                    // Save the login id and time in the Session
                    Session["LoginID"] = loginID;
                    Session["LoggedInTime"] = DateTime.Now.ToString();
                    Session["StudentName"] = studentloginidresult.Tables["StudentLoginIDCheck"].Rows[0]["Name"];
                    Session["StudentID"] = studentloginidresult.Tables["StudentLoginIDCheck"].Rows[0]["StudentID"];

                    //Redirect user to Main.aspx page
                    Response.Redirect("~/Student/StudentHomePage.aspx");
                }
                else
                {
                    if (loginID == "admin@ap.edu.sg" && password == "passAdmin")
                    {
                        // Save the login id and time in the Session
                        Session["LoginID"] = loginID;
                        Session["LoggedInTime"] = DateTime.Now.ToString();
                        Session["AdminID"] = 1; 

                        //Redirect user to Main.aspx page
                        Response.Redirect("~/SystemAdministrator/SystemAdminHomePage.aspx");
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM Parent WHERE EmailAddr=@enteredemail AND Password=@enteredpassword", conn);

                        cmd3.Parameters.AddWithValue("@enteredemail", loginID);
                        cmd3.Parameters.AddWithValue("@enteredpassword", password);

                        SqlDataAdapter daParentLoginID = new SqlDataAdapter(cmd3);
                        DataSet parentloginidresult = new DataSet();

                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        daParentLoginID.Fill(parentloginidresult, "ParentLoginIDCheck");
                        conn.Close();

                        if (parentloginidresult.Tables["ParentLoginIDCheck"].Rows.Count == 1)
                        {
                            // Save the login id and time in the Session
                            Session["LoginID"] = loginID;
                            Session["LoggedInTime"] = DateTime.Now.ToString();
                            Session["ParentName"] = parentloginidresult.Tables["ParentLoginIDCheck"].Rows[0]["ParentName"];
                            Session["ParentID"] = parentloginidresult.Tables["ParentLoginIDCheck"].Rows[0]["ParentID"];
                            //Redirect user to Main.aspx page
                            Response.Redirect("~/Parent/ParentHome.aspx");
                        }
                        else
                        {
                            //Display error message
                            lblMessage.Text = "Invalid Login Credentials!";
                        }
                    }
                }
            }
        }
    }
}