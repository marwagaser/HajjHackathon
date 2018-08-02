using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Companies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("getallCompanies", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (rdr.Read())
        {
            string companyName = rdr.GetString(rdr.GetOrdinal("name"));
            string companyField = rdr.GetString(rdr.GetOrdinal("field"));

            Label lbl_CompanyName = new Label();
            lbl_CompanyName.Text = companyName + "  speciliazes in ";
            form1.Controls.Add(lbl_CompanyName);


            Label lbl_CompanyField = new Label();
            lbl_CompanyField.Text = companyField + "  <br /> <br />";
            form1.Controls.Add(lbl_CompanyField);
        }
        //this is how you retrive data from session variable.
        string userId = Session["Username"].ToString();
        Response.Write("Logged-in User: " + userId);
    }
}