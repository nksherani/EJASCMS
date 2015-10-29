using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class TagViewPosts : System.Web.UI.Page
    {
        public string tag;
        public List<Post> Nposts;
        protected void Page_Load(object sender, EventArgs e)
        {
            tag = Request.QueryString["tag"].ToString();
            Nposts = new List<Post>();
            Nposts = Post.GetNPostsbyTag(1, 10, tag);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            globaldata.initial_post += globaldata.no_of_Posts;
            Nposts = Post.GetNPostsbyTag(globaldata.initial_post, globaldata.no_of_Posts,tag);
            globaldata.pages_visited++;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            globaldata.initial_post -= globaldata.no_of_Posts;
            Nposts = Post.GetNPostsbyTag(globaldata.initial_post, globaldata.no_of_Posts,tag);
            globaldata.pages_visited--;
        }
    }
}