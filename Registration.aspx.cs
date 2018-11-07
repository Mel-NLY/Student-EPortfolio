using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1
{
    public partial class CreateParentAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                //Create a new object from Parent Class
                ParentClass objParent = new ParentClass();

                //Pass data to the properties of the Staff Object,
                // do the nescessary data type conversion if need to.
                objParent.parentName = txtName.Text;
                objParent.emailAddr = txtEmail.Text;
                objParent.password = txtPassword.Text;

                // Call the add method to insert the Parent Record to database.
                int id = objParent.add();

                //Passing name and email as query string to
                //ConfirmAddParent.aspx page
                //& to add more Values
                Response.Redirect("ConfirmAddParent.aspx?name=" + txtName.Text +
                                  "&email=" + txtEmail.Text);

            }
        }
        protected void cuvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid) //other client-side validation passed
            {
                ParentClass objParent = new ParentClass();

                if(objParent.isEmailExist(txtEmail.Text) == true)
                {
                    args.IsValid = false; // Raise Error
                }
                else
                {
                    args.IsValid = true; // No Error
                }
            }
        }
    }
}