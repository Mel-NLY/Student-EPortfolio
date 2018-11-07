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
    public partial class UpdatedPortfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get results from database
            //Display results in respective labels

            //Input Student name
            lblStudentName.Text = Session["StudentName"].ToString();

            //Display portfolio image
            imgStudentPhoto.ImageUrl = "~/Images/Student/" + Session["StudentID"] + ".jpg";

            //Input values for about me textbox and achievement textbox

            //Create object with StudentClass class
            StudentClass objStudent = new StudentClass();

            //Insert studentID value
            objStudent.studentId = (int)Session["StudentID"];

            //Get values from class - getDetails() and
            //Display values 
            int error = objStudent.getDetails();
            if (error == 0)
            {
                lblAboutMe.Text = objStudent.description;
                lblAchievements.Text = objStudent.achievement;
            }
            else if (error == -2)
            {
                lblAboutMe.Text = "";
                lblAchievements.Text = "";
            }

            //Get the values from studentskillset and skillset

            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a StudentSkillSet and SkillSet record
            SqlCommand cmd = new SqlCommand("SELECT SkillSetName FROM SkillSet " +
                "WHERE SkillSetID IN " +
                "(SELECT SkillSetID FROM StudentSkillSet " +
                "WHERE StudentID=@studentid)", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the Studentid property of the Student class
            int studentid = Convert.ToInt32(Session["StudentID"]);
            cmd.Parameters.AddWithValue("@studentid", studentid);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daSkillSet = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet skillsetresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "SkillSetDetails" in DataSet
            daSkillSet.Fill(skillsetresult, "SkillSetDetails");
            
            //Close database connection
            conn.Close();

            if (skillsetresult.Tables["SkillSetDetails"].Rows.Count > 0)
            {
                //Fill SkillSetDetails Table with values from the Dataset
                DataTable table = skillsetresult.Tables["SkillSetDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["SkillSetName"]))
                {
                    string skillsetnames = "";

                    if (table.Rows.Count > 1)
                    {
                        for (int i = 0; i < table.Rows.Count - 1; i++)
                        {
                            skillsetnames += table.Rows[i]["SkillSetName"].ToString() + ", ";
                        }

                        int last = table.Rows.Count - 1;
                        skillsetnames += table.Rows[last]["SkillSetName"].ToString();
                    }

                    else
                    {
                        skillsetnames = table.Rows[0]["SkillSetName"].ToString();
                    }

                    lblSkillSets.Text = skillsetnames;
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/UpdatePortfolio.aspx");
        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/StudentHomePage.aspx");
        }
    }
}