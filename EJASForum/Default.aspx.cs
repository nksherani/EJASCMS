using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EJASForum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Installer.CreateTables();
            Response.Write("Plugin Activated<br/><a href=\"CPanel/Installer1.aspx\">Click Here to Move to Step2");
            //Response.Redirect("Pages/home.aspx");
        }
    }
}