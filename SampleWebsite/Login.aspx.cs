using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login(object sender, EventArgs e)
    {
        
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("LogIn", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        string iqama = txt_username.Text;
        string password = txt_password.Text;
        cmd.Parameters.Add(new SqlParameter("@iqama", iqama));
        cmd.Parameters.Add(new SqlParameter("@password", password));
        //SqlParameter pass = cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
        //pass.Value = password;

        // output parm
        SqlParameter count = cmd.Parameters.Add("@out", SqlDbType.Int);
        count.Direction = ParameterDirection.Output;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        if (count.Value.ToString().Equals("1"))
        {
            //this is how you store data to session variable.
            Session["Iqama"] = iqama;
            Response.Write("Passed");
            Response.Redirect("ChooseEmp", true);
        }
        else
        {
            Response.Write("Failed");
        }
    }



    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Schedule");
    }
}