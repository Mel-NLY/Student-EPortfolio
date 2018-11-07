using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.Parent
{
    public partial class RepliesDiscussion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page is loading onto the Web browser, not being refreshed due to
            //"postback" triggered by clicking of a submit button, or other
            //control that causes an auto-postback.
            if(!Page.IsPostBack)
            {
                displayReplies();
            }

        }

        private void displayReplies()
        {
            //Read connection string "Student_EPortfolio" from web.config file.
            //string strConn = ConfigurationManager.ConnectionStrings[""].ToString();

            //Instantiate a Sql Connection Object with the Connection String Read.
            //SqlConnection conn = new SqlConnection();

            //Instantiate a SqlCommand object, supply it with the SQL statement
            //SELECT and the connection object used for connecting to the database.
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Reply", conn);

            //Declare and instantiate DataAdapter Object
            //SqlDataAdapter daReply = new SqlDataAdapter(cmd);

            //Create a DataSet object to contain the records retrieved from database


            //Use DataAdapter to fetch data to a table "ReplyDetail" in DataSet.


            //Specify GridView to get data from table ""
            //in DataSet "result"


        }

        protected void gvReplies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the SelectedDatKey from GridView, which is the ParentNo,
            // and do the necessary data conversion.
            //int selectedParentNo = Convert.ToInt32(gvReplies.SelectedDataKey[0]);

            // Create a Branch object to contain the staff list of a Parent.

            //Call the get method of Reply Class to retrieve the
            //reply detail of a reply from database.
            //3objReply.ParentNo = selectedParentNo;

            //int errorCode = objReply.get(ref result);

            //if (errorCode == 0)
            {
                //Load Reply Info to the GridView: gvReply

            }
        }
    }
}