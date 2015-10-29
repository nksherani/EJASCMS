using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.cpanelPages
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int published=0;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            else
                published = 0;
            Page_class page = new Page_class(txtTitle.Text.Replace("'", "''"), published);
            page.SavePage(txtContent.Text.Replace("'", "''"));
        }
    }
}