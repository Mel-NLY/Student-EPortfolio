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
    public partial class UpdatePortfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StudentID"] != null)
                {
                    //Call in session StudentName
                    lblStudentName.Text = Session["StudentName"].ToString();
                    displaySkillSets();
                    displayPortfolioInfo();
                    displayStudentSkillSets();
                }
            }
        }
 
        private void displaySkillSets()
        {
            //Read connection string "Student_EPortfolio" from web config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SQLConnection object with the connection String read.
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object supply it with the SQL statement
            //SELECT that operates against the database, and the connection object used for connecting to the database.
            SqlCommand cmd = new SqlCommand("SELECT SkillSetName FROM SkillSet", conn);

            //Instantiate a DataAdapter object and pass the SQLCommand object created as parameter.
            SqlDataAdapter daSkillSets = new SqlDataAdapter(cmd);

            //Create a DataSet object to contain the records retrieved from database
            DataSet skillsetsresult = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "Skillsets" in dataset.
            //Dataset "skillsetsresult" will store the result of the SELECT operation.
            daSkillSets.Fill(skillsetsresult, "SkillSets");

            //A Connection should alwasy be closed, whether an error occur or not.
            conn.Close();

            //Specify checkbox to get data from table "SkillSets"
            chkSkillSets.DataSource = skillsetsresult.Tables["SkillSets"];

            chkSkillSets.DataValueField = "SkillSetName";
            chkSkillSets.DataTextField = "SkillSetName";

            //Display the list of data in CheckboxList
            chkSkillSets.DataBind();
        }

        //SkillSetID
        int skillSetID;

        private void displayStudentSkillSets()
        {
            //Input values for skillsets into checkboxlist
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statements
            SqlCommand cmd = new SqlCommand("SELECT SkillSetID FROM StudentSkillSet WHERE StudentID=@studentid", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved
            int studentID = (int)Session["StudentID"];
            cmd.Parameters.AddWithValue("@studentid", studentID);

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
                if (!DBNull.Value.Equals(table.Rows[0]["SkillSetID"]))
                {
                    if (table.Rows.Count >= 1)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            skillSetID = Convert.ToInt32(table.Rows[i]["SkillSetID"]);
                            skillSetID--;
                            //Check skillsets that are being inserted in table
                            chkSkillSets.Items[skillSetID].Selected = true;
                        }
                    }

                    else
                    {
                        for (int j = 0; j < chkSkillSets.Items.Count; j++)
                        {
                            //Uncheck all the skillset values
                            chkSkillSets.Items[j].Selected = false;
                        }
                    }
                }
            }
        }

        private void displayPortfolioInfo()
        {
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
                txtAboutMe.Text = objStudent.description;
                txtAchievement.Text = objStudent.achievement;
            }
            else if (error == -2)
            {
                txtAboutMe.Text = "";
                txtAchievement.Text = "";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string uploadedFile = "";
            if (upStudentPhoto.HasFile == true)
            {
                string savePath;

                // Find the filename extensions of the file to be uploaded
                string fileExt = Path.GetExtension(upStudentPhoto.FileName);

                // Rename the uploaded file with the studentid
                uploadedFile = Session["StudentID"] + fileExt;

                // MapPath - to find the complete path to thestudent folder in server
                savePath = Server.MapPath("~/Images/Student/") + uploadedFile;
                upStudentPhoto.SaveAs(savePath);

                try
                {
                    upStudentPhoto.SaveAs(savePath); // Upload the file to server
                    lblMsg.Text = "File uploaded successfully.";
                    imgStudentPhoto.ImageUrl = "~/Images/Student/" + uploadedFile;
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

        protected void btnUpdatePortfolio_Click(object sender, EventArgs e)
        {
            //Update Student records
            //Create object with StudentClass class
            StudentClass objStudent = new StudentClass();

            //Define the paramater used in SQL statement
            //Insert all values
            int studentID = (int)Session["StudentID"];
            objStudent.studentId = studentID;
            objStudent.description = txtAboutMe.Text;
            objStudent.achievement = txtAchievement.Text;
            objStudent.photo = imgStudentPhoto.ImageUrl;

            //Execute updateProfile() from StudentClass Class 
            objStudent.updateProfile();

            //Delete Student Skill Sets records
            //Create object with StudentSkillSet Class
            StudentSkillSet objStudentSkillSet = new StudentSkillSet();

            //Define the parameters used in SQL statement
            //Insert all values
            objStudentSkillSet.studentId = studentID;

            //Execute delete() from StudentSkillSet Class
            objStudentSkillSet.delete();

            //Get all the SkillSetIDs
            List<int> studentskillsetsid = new List<int>();
            for (int i = 0; i < chkSkillSets.Items.Count; i++)
            {
                //Get all the skillset values
                if (chkSkillSets.Items[i].Selected == true)
                {
                    studentskillsetsid.Add(i+1);
                }
            }

            for (int j = 0; j < studentskillsetsid.Count; j++)
            {
                //Define the parameters used in SQL statement 
                //Insert all values
                objStudentSkillSet.studentId = studentID;
                objStudentSkillSet.skillsetId = studentskillsetsid[j];

                //Execute add() from StudentSkillSet Class
                objStudentSkillSet.add();
            }
            
            //Redirect to Updated portfolio page 
            Response.Redirect("~/Student/UpdatedPortfolio.aspx");
        }

    }
}