using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJASForum.classes;

namespace EJASForum.CPanel
{
    public partial class Installer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Installer.ForumDetailsStarting(txtForumTitle.Text, txtDescription.Text);
            Response.Write("Details Saved<br/><a href=\"../Pages/beforehome.aspx\">Click Here to Move to Home</a>");

        }
    }
}