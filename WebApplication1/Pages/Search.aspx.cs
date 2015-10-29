using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        public static string query;
        public static List<Post> posts = new List<Post>();
        protected void Page_Load(object sender, EventArgs e)
        {
            query = Request.QueryString["query"];
            posts = Post.SearchPostContentbyWord(query);  
        }
    }
}