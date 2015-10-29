using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class PostView : System.Web.UI.Page
    {
        public List<Comment> Ncomments = new List<Comment>();
        public Post v;
        public int postid;
        protected void Page_Load(object sender, EventArgs e)
        {
            postid = Convert.ToInt32(Request.QueryString["postid"]);
            if (postid == 0)
                v = new Post();
            else
                v=Post.LoadPostbyId(postid);

            Ncomments = v.GetNComments(1, 20);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            v.PostComment(TextBox1.Text);
            Response.Redirect("PostView.aspx?postid="+postid);
        }
    }
}