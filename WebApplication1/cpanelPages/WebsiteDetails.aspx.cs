using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.cpanelPages
{
    public partial class WebsiteDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from WebsiteDetails";
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                txtTitle.Text = rdr["WebsiteName"].ToString();
                txtTagline.Text = rdr["Tagline"].ToString();
                txtCompany.Text = rdr["Company"].ToString();
                txtUrl.Text = rdr["URL"].ToString();
                txtAbout.Text = rdr["About"].ToString();
                txtFb.Text = rdr["FacebookPage"].ToString();
                txtTwitter.Text = rdr["TwitterTimeline"].ToString();
                txtGithub.Text = rdr["Github"].ToString();
            }
            con1.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "update WebsiteDetails set WebsiteName=@title,Tagline=@tagline,Company=@company,"+
                "URL=@url,About=@about,FacebookPage=@fb,TwitterTimeline=@twitter,Github=@github,DateModified=@dtm";

            SqlCommand com1 = new SqlCommand(q1, con1);
            if(txtTitle.Text!="")
                com1.Parameters.AddWithValue("@title", txtTitle.Text);
            else
                com1.Parameters.AddWithValue("@title", DBNull.Value);
            if(txtTagline.Text!="")
            com1.Parameters.AddWithValue("@tagline", txtTagline.Text);
            else
                com1.Parameters.AddWithValue("@tagline", DBNull.Value);
            if(txtCompany.Text!="")
            com1.Parameters.AddWithValue("@company", txtCompany.Text);
            else
                com1.Parameters.AddWithValue("@company", DBNull.Value);
            if(txtUrl.Text!="")
                com1.Parameters.AddWithValue("@url", txtUrl.Text);
            else
                com1.Parameters.AddWithValue("@url", DBNull.Value);
            if (txtFb.Text != "")
                com1.Parameters.AddWithValue("@fb", txtFb.Text);
            else
                com1.Parameters.AddWithValue("@fb", DBNull.Value);
            if (txtTwitter.Text != "")
                com1.Parameters.AddWithValue("@twitter", txtTwitter.Text);
            else
                com1.Parameters.AddWithValue("@twitter", DBNull.Value);
            if (txtGithub.Text != "")
                com1.Parameters.AddWithValue("@github", txtGithub.Text);
            else
                com1.Parameters.AddWithValue("@github", DBNull.Value);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            if (txtAbout.Text != "")
                com1.Parameters.AddWithValue("@about", txtAbout.Text);
            else
                com1.Parameters.AddWithValue("@about", DBNull.Value);

            con1.Open();
            com1.ExecuteReader();
            con1.Close();

            lblStatus.Text = "Details Updated Successfully";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }
    }
}