using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.Pages
{
    public partial class CreateThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            Session["forumid"] = 1;
            List<string> categories = new List<string>();
            categories = ForumCategory.GetAllCategoryNames(Convert.ToInt32(Session["forumid"]));
            categories.Insert(0, "Select a category");
            drpCategory.DataSource = categories;
            drpCategory.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int published = 0;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            Session["userid"] = 1;
            ForumThread thread = new ForumThread(txtTitle.Text, txtContent.Text, drpSection.SelectedItem.Text, published, Convert.ToInt32(Session["userid"]));
            thread.CreateThreadintoDb();
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCategory.SelectedIndex > 0)
            {
                drpSection.DataSource = ForumSection.GetAllSectionNames(drpCategory.SelectedItem.Text);
                drpSection.DataBind();
            }
            else
            {
                drpSection.Items.Clear();
                drpSection.Items.Add("Select a section");
            }

        }
    }
}