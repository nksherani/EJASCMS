using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Pages
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btninstall_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
            string q1 = "insert into database_parameters(ServerName,DatabaseName,Username,Password) values('"+
                txtservername.Text+"','"+txtdbname.Text+"','"+txtdbusername.Text+"','"+txtdbpassword.Text+"')";
            SqlCommand com1 = new SqlCommand(q1,con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            globaldata.AddUpdateConnectionString("globaldb", txtservername.Text, txtdbname.Text, txtdbusername.Text, txtdbpassword.Text);
            Response.Redirect("install2.aspx");
        }
    }
}