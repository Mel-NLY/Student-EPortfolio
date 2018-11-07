using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WEBAssignmentCheckpoint1
{
    public partial class UpdateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["projectid"] != null)
                {
                    displayProjectInfo();
                    displayLeaderInfo();
                    displayMemberInfo();
                }
            }
        }

        private void displayProjectInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project p " +
                "INNER JOIN ProjectMember pm " +
                "ON p.ProjectID = pm.ProjectID " +
                "WHERE p.ProjectID = @projectID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daProject = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet projectresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "ProjectDetails" in DataSet
            daProject.Fill(projectresult, "ProjectDetails");

            //Close database connection
            conn.Close();

            if (projectresult.Tables["ProjectDetails"].Rows.Count > 0)
            {
                //Fill ProjectDetails Object with values from the Dataset
                DataTable table = projectresult.Tables["ProjectDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["ProjectID"]))
                {
                    txtUpdateProjName.Text = table.Rows[0]["Title"].ToString();
                    txtURL.Text = table.Rows[0]["ProjectURL"].ToString();
                    txtUpdateProjDescription.Text = table.Rows[0]["Description"].ToString();
                }
            }
        }

        private void displayLeaderInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement
            SqlCommand cmd = new SqlCommand("SELECT Name, StudentID FROM Student " +
                "WHERE StudentID = " +
                "(SELECT StudentID " +
                "FROM ProjectMember " +
                "WHERE ProjectID = @projectID " +
                "AND Role = 'Leader')", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daLeader = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet leaderresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "LeaderDetails" in DataSet
            daLeader.Fill(leaderresult, "LeaderDetails");

            //Close database connection
            conn.Close();

            if (leaderresult.Tables["LeaderDetails"].Rows.Count > 0)
            {
                //Fill LeaderDetails Object with values from the Dataset
                DataTable table = leaderresult.Tables["LeaderDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                {
                    lblLeader.Text = table.Rows[0]["Name"].ToString();
                    int leaderID = Convert.ToInt32(table.Rows[0]["StudentID"]);

                    //Check if current student id is the same as the leader id
                    int studentID = (int)Session["StudentID"];

                    if (studentID == leaderID)
                    {
                        //Enable textbox for editing if the logged in student is the leader of the project
                        txtMember.Enabled = true;
                    }

                    else
                    {
                        //Disable textbox if logged in student is just a regular member
                        txtMember.Enabled = false;
                    }
                }
            }
        }

        private void displayMemberInfo()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statements
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Student " +
                "WHERE StudentID IN " +
                "(SELECT StudentID " +
                "FROM ProjectMember " +
                "WHERE ProjectID = @projectID " +
                "AND Role = 'Member')", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            cmd.Parameters.AddWithValue("@projectID", projectId);

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
                //Fill MemberDetails Object with values from the Dataset
                DataTable table = memberresult.Tables["MemberDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["Name"]))
                {
                    string members = "";

                    if (table.Rows.Count > 1)
                    {
                        for (int i = 0; i < table.Rows.Count - 1; i++)
                        {
                            members += table.Rows[i]["Name"].ToString() + ",";
                        }

                        int last = table.Rows.Count - 1;
                        members += table.Rows[last]["Name"].ToString();
                    }

                    else
                    {
                        members = table.Rows[0]["Name"].ToString();
                    }

                    txtMember.Text = members;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string uploadedFile = "";
            if (upPoster.HasFile == true)
            {
                string savePath;

                // Find the filename extensions of the file to be uploaded
                string fileExt = Path.GetExtension(upPoster.FileName);

                // Rename the uploaded file with the project's name
                uploadedFile = Request.QueryString["projectid"] + fileExt;

                // MapPath - to find the complete path to the project folder in server
                savePath = Server.MapPath("~/Images/Project/") + uploadedFile;
                upPoster.SaveAs(savePath);

                try
                {
                    upPoster.SaveAs(savePath); // Upload the file to server
                    lblMsg.Text = "File uploaded successfully.";
                    imgPoster.ImageUrl = "~/Images/Project/" + uploadedFile;
                }
                catch (IOException)
                {
                    // File IO error, could due to access rights denied
                    lblMsg.Text = "File uploading fail!";
                }
                catch (Exception ex) // Other type of error
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }

        protected void btnReflection_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            Response.Redirect("~/Student/ProjectReflection.aspx?" + "projectid=" + projectId);
        }

        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            //Update Project records
            //Create object with Project class
            Project objProject = new Project();

            //Define the paramter used in SQL statement
            //Insert all values
            int projectId = Convert.ToInt32(Request.QueryString["projectid"]);
            objProject.projectId = projectId;
            objProject.title = txtUpdateProjName.Text;
            objProject.projectPoster = imgPoster.ImageUrl;
            objProject.projectURL = txtURL.Text;
            objProject.description = txtUpdateProjDescription.Text;

            //Execute update() from Project Class 
            objProject.update();

            // Remove any student that was already recorded as a member
            //Create objecct with ProjectMember class
            ProjectMember objprojmem = new ProjectMember();

            //Define the paramter used in SQL statement
            //Insert all values
            objprojmem.projectId = projectId;

            //Execute delete() from ProjectMember Class 
            objprojmem.deleteMember();

            // Add student as member
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

                        //Instantiate a SqlCommand object, supply it with a SELECT SQL statement
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
                                objProjectMember.projectId = projectId;
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