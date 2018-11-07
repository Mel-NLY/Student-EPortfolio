using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEBAssignmentCheckpoint1
{
    public partial class StudentePortfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displaystudenportfolio();
            }
        }

        public void displaystudenportfolio()
        {
            //Read connection string "Student_EPortfolio" from web.config file
            string strConn = ConfigurationManager.ConnectionStrings["Student_EPortfolio"].ToString();

            //Instantiate a SqlConnection object with the Connection String read
            SqlConnection conn = new SqlConnection(strConn);

            // Instantiate a SqlCommand object, supply it with the SQL Statement
            //SELECT that operates against the database, and the connection object
            //used for connecting to the database
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Status = 'Y'", conn);

            //Instantiate a Datadapter object and pass the SqlCommand object
            //created as a parameter
            SqlDataAdapter daPortfolio = new SqlDataAdapter(cmd);

            //Create a Dataset object to contain the records retrieved from database
            DataSet result = new DataSet();

            //A connection must be opened before any operations made.
            conn.Open();

            //Use DataAdapter to fetch data to a table "PortfolioDetails" in DataSet
            //DataSet "result" will store the result of the SELECT operation
            daPortfolio.Fill(result, "PortfolioDetails");

            //A connection should always be closed whether error occurs or not
            conn.Close();

            //Specify GridView to get data from table "PortfolioDetails"
            //in DataSet "result'
            gvStudentPortfolio.DataSource = result.Tables["PortfolioDetails"];

            //Display the list of data in GridView
            gvStudentPortfolio.DataBind();
        }
    }
}