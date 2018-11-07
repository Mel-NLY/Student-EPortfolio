using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public class SkillSet
    {
        public int skillsetId { get; set; }
        public string skillsetname { get; set; }

        public int getDetails()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            //Instantiate a SqlCommand object, supply it with a SELECT SQL statement which retrieves all attributes of a StudentSkillSet record
            SqlCommand cmd = new SqlCommand("SELECT * FROM SkillSet WHERE SkillSetID = @skillsetID", conn);

            //Define the paramter used in SQL statement, value for the parameter is retrieved from the SkillSetID property of the StudentSkillSet class
            cmd.Parameters.AddWithValue("@skillsetID", skillsetId);

            //Instantiate a DataAdapter object, pass the SqlCommand
            //object created as a parameter
            SqlDataAdapter daSkillSet = new SqlDataAdapter(cmd);

            //Create a DataSet object result
            DataSet SkillSetresult = new DataSet();

            //Open a database connection
            conn.Open();

            //Use DataAdaptor to fetch data to a table "StudentDetails" in DataSet
            daSkillSet.Fill(SkillSetresult, "SkillSetDetails");

            //Close database connection
            conn.Close();

            if (SkillSetresult.Tables["SkillSetDetails"].Rows.Count > 0)
            {
                //Fill StudentSkillSet Object with values from the Dataset
                DataTable table = SkillSetresult.Tables["SkillSetDetails"];
                if (!DBNull.Value.Equals(table.Rows[0]["SkillSetID"]))
                {
                    skillsetname = table.Rows[0]["SkillSetName"].ToString();
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