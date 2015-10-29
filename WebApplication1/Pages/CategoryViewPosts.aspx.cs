using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class CategoryViewPosts : System.Web.UI.Page
    {
        public int catid;
        public List<Post> Nposts;
        public string catname;
        protected void Page_Load(object sender, EventArgs e)
        {
            catname = Request.QueryString["category"];
            catid = Convert.ToInt32(Request.QueryString["catid"]);
            Nposts = Post.GetNPostsbyCategory(globaldata.initial_post, globaldata.no_of_Posts, catid);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            globaldata.initial_post += globaldata.no_of_Posts;
            Nposts = Post.GetNPostsbyCategory(globaldata.initial_post, globaldata.no_of_Posts,catid);
            globaldata.pages_visited++;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            globaldata.initial_post -= globaldata.no_of_Posts;
            Nposts = Post.GetNPostsbyCategory(globaldata.initial_post, globaldata.no_of_Posts,catid);
            globaldata.pages_visited--;
        }
    }
}