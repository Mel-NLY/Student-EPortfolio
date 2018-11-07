using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class ApproveViewingRequestSysAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayViewingRequest();
            }
        }

        private void displayViewingRequest()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM ViewingRequest WHERE Status='P' ORDER BY ViewingRequestID", conn);

            SqlDataAdapter daViewRequest = new SqlDataAdapter(cmd);

            DataSet result = new DataSet();

            conn.Open();

            daViewRequest.Fill(result, "ViewRequest");

            conn.Close();

            gvViewingRequest.DataSource = result.Tables["ViewRequest"];

            gvViewingRequest.DataBind();

            if (result.Tables["ViewRequest"].Rows.Count > 0)
            {
                string rows = "yes";
            }
            else
                lblUpdate.Text += "No available request for Viewing at the moment";
        }

        protected void gvViewingRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int i = Convert.ToInt32(e.CommandArgument);

                ApproveViewingRequestSysAdmin sysApprove = new ApproveViewingRequestSysAdmin();

                sysApprove.requestId = Convert.ToInt32(gvViewingRequest.Rows[i].Cells[0].Text);

                int update = sysApprove.updateStatus("A");

                lblUpdate.Text = "You've approved the request, ";

                displayViewingRequest();
            }
            else if (e.CommandName == "Reject")
            {
                int i = Convert.ToInt32(e.CommandArgument);

                ApproveViewingRequestSysAdmin sysApprove = new ApproveViewingRequestSysAdmin();

                sysApprove.requestId = Convert.ToInt32(gvViewingRequest.Rows[i].Cells[0].Text);

                int update = sysApprove.updateStatus("R");

                lblUpdate.Text = "You've reject the request, ";

                displayViewingRequest();
            }
        }
    }
}