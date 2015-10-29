using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class NewPagebyDB : System.Web.UI.Page
    {
        public static Post post;
        public static bool posted;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = 1;
            if (IsPostBack)
                return;
            populateCategoryList();

        }

        public void populateCategoryList()
        {
            string q1 = "select categoryName from categories";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            List<string> cat = new List<string>();
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                cat.Add(rdr[0].ToString());
            }
            lstCategories.DataSource = cat;
            lstCategories.DataBind();
            cat.Insert(0, "Select Parent Category");
            drpParentCategory.DataSource = cat;
            drpParentCategory.DataBind();
            con1.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> categories = new List<string>();
            foreach (ListItem item in lstCategories.Items)
            {
                if (item.Selected)
                {
                    categories.Add(item.Text);
                }
            }
            int published;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            else
                published = 0;
            post = new Post(txtTitle.Text.Replace("'", "''"), txtContent.Text.Replace("'", "''"), published, categories, txtNewTags.Text.Replace("'", "''"));
            if (post.published == 1)
                posted = true;
          }
        
        protected void btnNewCategory_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "";
            if(drpParentCategory.SelectedValue.ToString().Trim().Equals("Select Parent Category".Trim()))
                q1 = "INSERT INTO CATEGORIES(CATEGORYNAME) values('" + txtNewCategory.Text + "')";

            else
                q1 = "INSERT INTO CATEGORIES(CATEGORYNAME,PARENTNAME) values('" + txtNewCategory.Text + "','" + drpParentCategory.SelectedItem.Text + "')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            populateCategoryList();
            
        }

                
    }
}