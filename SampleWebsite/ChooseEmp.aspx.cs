using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



public partial class ChooseEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button1_Click_Click(object sender, ImageClickEventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("viewServices", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        string iqama = Txt.Text;
        cmd.Parameters.Add(new SqlParameter("@iqama", iqama));
        //SqlParameter pass = cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
        //pass.Value = password

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();


        Session["Iqama"] = iqama;
        Response.Write("Passed");
        Response.Redirect("ServicePage", true);

    }
}