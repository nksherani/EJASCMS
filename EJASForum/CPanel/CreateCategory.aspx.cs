using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.CPanel
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ForumCategory category;
            int published;
            if (drpPublish1.SelectedIndex == 0)
                published = 1;
            else
                published = 0;
            Session["userid"] = 1;
            Session["forumid"] = 1;
            if(!string.IsNullOrEmpty(txtDesc1.Text))
                category = new ForumCategory(txtTitle1.Text,Convert.ToInt32(Session["userid"]),published,Convert.ToInt32(Session["forumid"]),txtDesc1.Text);
            else
                category = new ForumCategory(txtTitle1.Text, Convert.ToInt32(Session["userid"]), published, Convert.ToInt32(Session["forumid"]));
            category.CreateCategoryintoDb();
        }
    }
}