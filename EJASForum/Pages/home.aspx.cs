using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.Pages
{
    public partial class home : System.Web.UI.Page
    {
        public Forum EJASForum;
        public List<ForumThread> Nthreads;
        public int _sectionid;
        protected void Page_Load(object sender, EventArgs e)
        {
            Nthreads = new List<ForumThread>();
            Session["userid"] = 1;
            EJASForum = new Forum();
            Session["forumid"] = EJASForum.ForumId;
        }

        
    }
}