using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class UploadStudentPhoto : System.Web.UI.Page
    {
        bool correctFileExtension = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                displayStudent();
        }

        private void displayStudent()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM Student", conn);

            SqlDataAdapter daStudent = new SqlDataAdapter(cmd);

            DataSet result = new DataSet();

            conn.Open();

            daStudent.Fill(result, "StudentDetails");

            conn.Close();

            ddlChooseStudent.DataSource = result.Tables["StudentDetails"];

            ddlChooseStudent.DataTextField = "Name";

            ddlChooseStudent.DataValueField = "StudentID";

            ddlChooseStudent.DataBind();

            ddlChooseStudent.Items.Insert(0, "--Select--");
        }

        protected void btnImgConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && correctFileExtension == true)
            {
                Student objStudent = new Student();

                objStudent.studentId = Convert.ToInt32(ddlChooseStudent.SelectedValue);

                string uploadedFile = "";
                string savePath;

                string fileExt = Path.GetExtension(upPhoto.FileName);

                uploadedFile = ddlChooseStudent.SelectedItem.Text + ddlChooseStudent.SelectedIndex.ToString() + fileExt;

                objStudent.photo = uploadedFile;

                savePath = MapPath("~/Images/" + uploadedFile);

                try
                {
                    upPhoto.SaveAs(savePath);
                    int errorCode = objStudent.insertPhoto();
                    if (errorCode == 0)
                    {
                        lblMsg.Text = "File uploaded successfully.";
                        imgStudentPhoto.ImageUrl = "~/Images/" + uploadedFile;
                        ddlChooseStudent.SelectedIndex = 0;
                    }
                    else if (errorCode == 1)
                    {
                        lblMsg.Text = "Unable to save record to database";
                    }
                }
                catch (IOException)
                {
                    lblMsg.Text = "File uploading fail";
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }

        protected void cuvImgExtension_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (upPhoto.HasFile == true)
            {
                string fileExt = Path.GetExtension(upPhoto.FileName);

                if (fileExt != ".jpg")
                {
                    args.IsValid = false;
                    btnImgConfirm.Enabled = false;
                }
                else
                {
                    args.IsValid = true;
                    correctFileExtension = true;
                    btnImgConfirm.Enabled = true;
                    lblMsg.Text = "Please upload a photo";
                }
            }
        }
    }
}