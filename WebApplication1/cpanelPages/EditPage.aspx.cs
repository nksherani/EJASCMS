using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;
namespace WebApplication1.cpanelPages
{
    public partial class EditPage : System.Web.UI.Page
    {
        
        public static Page_class page;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            string pageid = Request.QueryString["pageid"];
            page = Page_class.GetPagebyID(pageid);
            globaldata.PageContents = Page_class.GetTextofPage(page.pageName);
            txtTitle.Text = globaldata.PageContents[1];
            txtContent.Text = globaldata.PageContents[3];
            if (page.published == 1)
                drpPublish.SelectedIndex = 0;
            else
                drpPublish.SelectedIndex = 1;
            txtSelectedIndex.Text = drpPublish.SelectedIndex.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int published;
            globaldata.PageContents[1] = txtTitle.Text;
            globaldata.PageContents[3] = txtContent.Text;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            else
                published = 0;
            bool toggle = Convert.ToBoolean(txtToggle.Text);
            page.EditPage(globaldata.PageContents,published,toggle);
        }

        protected void drpPublish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSelectedIndex.Text == drpPublish.SelectedIndex.ToString())
                txtToggle.Text = Convert.ToString(false);
            else
                txtToggle.Text = Convert.ToString(true);
        }
    }
}