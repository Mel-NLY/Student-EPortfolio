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
    public partial class CreateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // Create a new object from the Project Class
            Project objProject = new Project();

            // Pass data to the properties of the Project object
            objProject.title = txtProjName.Text;
            objProject.description = txtProjDescription.Text;
            objProject.projectPoster = "";
            objProject.projectURL = "";

            // Call the add method to insert the project record to database
            int projid = objProject.add();

            // Craete a new object from the ProjectMember Class
            ProjectMember objProjectLeader = new ProjectMember();

            // Pass data to the properties of the ProjectMember object
            objProjectLeader.projectId = projid;
            objProjectLeader.studentId = Convert.ToInt32(Session["StudentID"]);
            objProjectLeader.role = "Leader";
            objProjectLeader.reflection = "";

            // Call the add method to insert the project record to database
            objProjectLeader.add();

            if (txtMember.Text != "")
            {
                //Get StudentID

                //Get member name from textbox and store into array separated by comma
                string member = txtMember.Text;
                List<string> memberList = member.Split(',').ToList();
                 
                for (int i = 0; i < memberList.Count; i++)
                {
                    if (memberList[i] != Session["StudentName"].ToString())
                    {
                        //Read connection string "Student_EPortfolio" from web.config file
                        string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

                        //Instantiate a SqlConnection object with the Connection String read
                        SqlConnection conn = new SqlConnection(strConn);

                        //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a Student record
                        SqlCommand cmd = new SqlCommand("SELECT StudentID FROM Student WHERE Name=@name", conn);

                        //Define the paramter used in SQL statement, value for the parameter is retrieved
                        cmd.Parameters.AddWithValue("@name", memberList[i]);

                        //Instantiate a DataAdapter object, pass the SqlCommand
                        //object created as a parameter
                        SqlDataAdapter daMember = new SqlDataAdapter(cmd);

                        //Create a DataSet object result
                        DataSet memberresult = new DataSet();

                        //Open a database connection
                        conn.Open();

                        //Use DataAdaptor to fetch data to a table "MemberDetails" in DataSet
                        daMember.Fill(memberresult, "MemberDetails");

                        //Close database connection
                        conn.Close();

                        if (memberresult.Tables["MemberDetails"].Rows.Count > 0)
                        {
                            //Fill StudentSkillSet Object with values from the Dataset
                            DataTable table = memberresult.Tables["MemberDetails"];
                            if (!DBNull.Value.Equals(table.Rows[0]["StudentID"]))
                            {
                                // Craete a new object from the ProjectMember Class
                                ProjectMember objProjectMember = new ProjectMember();

                                // Pass data to the properties of the ProjectMember object
                                objProjectMember.projectId = projid;
                                objProjectMember.studentId = Convert.ToInt32(table.Rows[0]["StudentID"]);
                                objProjectMember.role = "Member";
                                objProjectMember.reflection = "";

                                // Call the add method to insert the project record to database
                                objProjectMember.add();
                            }
                        }
                    }
                    
                }
            }

            Response.Redirect("~/Student/ProjectList.aspx");
        }
    }
}