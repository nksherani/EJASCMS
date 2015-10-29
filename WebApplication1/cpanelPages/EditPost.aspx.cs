using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WebApplication1.cs;

namespace WebApplication1.cpanelPages
{
    public partial class EditPost : System.Web.UI.Page
    {
        public Post post;
        public bool toggle;
        public static string postid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            txtToggleValue.Text = "";
            populateCategoryList();
            postid = Request.QueryString["postid"].ToString();
            //postid = "21";
            post = Post.LoadPostbyIdAll(Convert.ToInt32(postid));
            txtTitle.Text = post.title;
            txtContent.Text = post.content;
            if (post.published == 0)
                drpPublish.SelectedIndex = 1;
            else
                drpPublish.SelectedIndex = 0;
            //populating multiselect list from db
            for(int i = 0; i < lstCategories.Items.Count; i++)
            {
                if((post.categories.Find(x=>x.categoryName==lstCategories.Items[i].Text)!=null))
                    lstCategories.Items[i].Selected = true;
            }
            int count = 0;
            foreach(var tag in post.tags)
            {
                if(count!=0)
                txtNewTags.Text += ",";
                txtNewTags.Text += tag.tag;
                count++;
                
            }
            if (drpPublish.SelectedItem.Text == "Yes")
                txtToggle.Text = "0";
            else
                txtToggle.Text = "1";


        }

        protected void btnNewCategory_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "";
            if (drpParentCategory.SelectedValue.ToString().Trim().Equals("Select Parent Category".Trim()))
                q1 = "INSERT INTO CATEGORIES(CATEGORYNAME) values('" + txtNewCategory.Text + "')";

            else
                q1 = "INSERT INTO CATEGORIES(CATEGORYNAME,PARENTNAME) values('" + txtNewCategory.Text + "','" + drpParentCategory.SelectedItem.Text + "')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            populateCategoryList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            postid = Request.QueryString["postid"].ToString();
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "DELETE FROM TAGS WHERE PagePostId=" + postid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            List<string> categories = new List<string>();
            foreach (ListItem item in lstCategories.Items)
            {
                if (item.Selected)
                {
                    categories.Add(item.Text.Replace("'", "''"));
                }
            }
            int published;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            else
                published = 0;
            if(txtToggleValue.Text!="")
            toggle = Convert.ToBoolean(txtToggleValue.Text);
            toggle = false;
            //use update query
            Post.UpdatePost(Convert.ToInt32(postid), txtTitle.Text.Replace("'", "''"), txtContent.Text.Replace("'", "''"), published,toggle, categories, txtNewTags.Text.Replace("'", "''"));

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

        protected void drpPublish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtToggle.Text != drpPublish.SelectedIndex.ToString())
                toggle = true;
            else
                toggle = false;
            txtToggleValue.Text = toggle.ToString();
        }
    }
}