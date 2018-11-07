using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1.SystemAdministrator
{
    public class Skillset
    {
        public int skillSetId { get; set; }
        public string skillSetName { get; set; }

        public int add()
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("INSERT INTO SkillSet (SkillSetName)" + "OUTPUT INSERTED.SkillSetID " + "VALUES(@skillSetName)", conn);

            cmd.Parameters.AddWithValue("@skillSetName", skillSetName);

            conn.Open();

            int id = (int)cmd.ExecuteScalar();

            conn.Close();

            return 5;
        }

        public bool isSkillSetExist(string skillSet)
        {
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            SqlConnection conn = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM SkillSet WHERE SkillSetName=@selectedSkillSet", conn);

            cmd.Parameters.AddWithValue("@selectedSkillSet", skillSet);

            SqlDataAdapter daSkillSet = new SqlDataAdapter(cmd);

            DataSet result = new DataSet();

            conn.Open();

            daSkillSet.Fill(result, "SkillSetDetails");

            conn.Close();

            if (result.Tables["SkillSetDetails"].Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}