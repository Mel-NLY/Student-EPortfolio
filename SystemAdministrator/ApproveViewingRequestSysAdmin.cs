using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public partial class ApproveViewingRequestSysAdmin
    {
        public int requestId { get; set; }
        public string status { get; set; }

        public int updateStatus(string status)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("UPDATE ViewingRequest SET Status=@status WHERE ViewingRequestID=@selectedViewingRequestId", conn);

            cmd.Parameters.AddWithValue("@status", status);

            cmd.Parameters.AddWithValue("@selectedViewingRequestId", requestId);

            conn.Open();

            int count = cmd.ExecuteNonQuery();

            conn.Close();

            return 0;
        }
    }
}