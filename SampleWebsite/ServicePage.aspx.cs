using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class ServicePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.Visible = false;
        //txt_price.Visible = false;
        String connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("viewServices", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@iqama", Session["Iqama"].ToString()));
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        
            GridView1.DataSource = dt;
            GridView1.DataBind();
      
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        String connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("calcSum", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@iqama", Session["Iqama"].ToString()));
        
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        GridView2.Visible = true;
        btn_choose.Visible = false;
        //  cmd.Parameters.Add(new SqlParameter("@iqama", Session["Iqama"].ToString()));
        // SqlParameter count = cmd.Parameters.Add("@sum", SqlDbType.Int);
        //count.Direction = ParameterDirection.Output;

    }
}