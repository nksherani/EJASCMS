using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.CPanel
{
    public partial class CreateSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            //Session["forumid"] = 1;
            drpCategories.DataSource = ForumCategory.GetAllCategoryNames(Convert.ToInt32(Session["forumid"]));
            drpCategories.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["userid"] = 1;
            int published=0;
            if (drpPublish1.SelectedIndex == 0)
                published = 1;
            ForumSection section = new ForumSection(txtTitle1.Text,Convert.ToInt32(Session["userid"]) , drpCategories.SelectedItem.Text, published, txtDesc1.Text);
            section.CreateSectionintoDb();
        }
    }
}