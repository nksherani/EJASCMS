using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string server, database, username, password;
            server = "";
            database = "";
            username = password = "";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
            string q1 = "SELECT * FROM database_parameters";
            con1.Open();
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr = com1.ExecuteReader();
            if (rdr.HasRows)
            {
                Response.Redirect("Pages/home.aspx");
            }
            else
            Response.Redirect("Pages/install1.aspx");
        }

            }

   
}