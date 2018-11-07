using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WEBAssignmentCheckpoint1
{
    public class ViewingRequest
    {
        public int viewingRequestId { get; set; }
        public int parentId { get; set; }
        public string studentName { get; set; }
        public int studentId { get; set; }
        public char status { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a viewingRequest record
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewingRequest WHERE ParentID = @parentID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the viewingRequestid property of the viewingRequest class
            cmd.Parameters.AddWithValue("@parentID", parentId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daviewingRequest = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet viewingRequestresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "viewingRequestDetails" in DataSet
            daviewingRequest.Fill(viewingRequestresult, "viewingRequestDetails");

            //Close database connection
            conn.Close();

            if (viewingRequestresult.Tables["viewingRequestDetails"].Rows.Count > 0)
            {
                //Fill viewingRequest Object with values from the Dataset
                DataTable table = viewingRequestresult.Tables["viewingRequestDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["StudentName"]))
                {
                    studentName = table.Rows[0]["StudentName"].ToString();
                }
                return 0; // No error occurs
            }
            else
            {
                return -2; //Record not found
            }
        }
    }
}