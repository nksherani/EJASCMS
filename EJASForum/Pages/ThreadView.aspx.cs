using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJASForum.classes;
using System.Data.SqlClient;
using System.Configuration;

namespace EJASForum.Pages
{
    public partial class ThreadView : System.Web.UI.Page
    {
        public static ForumThread thr;
        public List<ForumReply> NReplies;
        public string section,category,reply;
        public static int reply_pages;
        protected void btnReply_Click(object sender, EventArgs e)
        {
            thr.PostReply(txtContent.Text);
            Response.Redirect("ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+section+"&category="+category);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            reply_pages = 1;
            NReplies = new List<ForumReply>();
            int threadid=Convert.ToInt32(Request.QueryString["threadid"]);
            section = Request.QueryString["section"];
            category = Request.QueryString["category"];
            reply = Request.QueryString["reply"];
            thr = new ForumThread();
            thr.GetThread(threadid);
            NReplies = thr.GetNReplies(Convert.ToInt32(reply),10);
        }
    }
}