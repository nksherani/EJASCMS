using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum
{
    public partial class Uninstall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string folder = Request.Cookies["plugin"]["folder"];
            string pageurl = Request.Cookies["plugin"]["pageurl"];
            Installer.DropTables(pageurl,folder);
            
        }
    }
}