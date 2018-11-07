using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.Student
{
    public partial class ViewSuggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["suggestionid"] != null)
                {
                    // Create a new MentorSuggestion object
                    MentorStudentSuggestion objStuMenSugg = new MentorStudentSuggestion();

                    // Read SuggestionID from query string
                    objStuMenSugg.suggestionId = Convert.ToInt32(Request.QueryString["suggestionid"]);

                    // Load studentmentorsuggestion information to controls
                    int errorCode = objStuMenSugg.getDetails();
                    if (errorCode == 0)
                    {
                        lblMentorName.Text = objStuMenSugg.mentorName;
                        lblSuggestion.Text = objStuMenSugg.description;
                    }

                    else if (errorCode == -2)
                    {
                        lblMentorName.Text = "There is no results";
                        lblSuggestion.Text = "There is no results";
                    }
                }
            }
        }
    }
}