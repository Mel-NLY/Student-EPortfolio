using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class CreateSkillSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSkillSetStatus.Text = "";
        }

        protected void btnSkillSetConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Skillset objSkillset = new Skillset();

                objSkillset.skillSetName = txtSkillSetsCreated.Text;

                int id = objSkillset.add();

                txtSkillSetsCreated.Text = "";

                if (id == 5) //To make sure it is inserted
                {
                    lblSkillSetStatus.Text = "Skillset successfully inserted";
                }
            }
        }

        protected void cuvSkillSets_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                Skillset objSkillset = new Skillset();

                if (objSkillset.isSkillSetExist(txtSkillSetsCreated.Text) == true)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
        }

        protected void btnSkillSetReset_Click(object sender, EventArgs e)
        {
            txtSkillSetsCreated.Text = "";
            lblSkillSetStatus.Text = "SkillSet field is Cleared";
        }
    }
}