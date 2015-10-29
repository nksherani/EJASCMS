using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class home : System.Web.UI.Page
    {
        //public static List<string> categories;
        public static List<Post> Nposts = new List<Post>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();
            if (Convert.ToInt32(Session["expires"]) ==1)
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                //Response.Cache.SetNoStore();
                Session["expires"] = 0;
            }

            

            Nposts = Post.LoadFirstNPosts(globaldata.no_of_Posts);
            if (IsPostBack)
                return;
            globaldata.initial_post = 1;
            globaldata.no_of_Posts = 10;
            globaldata.pages_visited=0;
            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            globaldata.initial_post += globaldata.no_of_Posts;
            Nposts = Post.LoadNextNPosts(globaldata.initial_post, globaldata.no_of_Posts);
            globaldata.pages_visited++;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            globaldata.initial_post -= globaldata.no_of_Posts;
            Nposts = Post.LoadNextNPosts(globaldata.initial_post, globaldata.no_of_Posts);
            globaldata.pages_visited--;
        }
    }
}