using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using EJASForum.classes;

namespace EJASForum.Pages
{
    public partial class CategoryView : System.Web.UI.Page
    {
        public ForumCategory cat;
        public int thread;
        public string category;
        public List<ForumThread> threads;
        protected void Page_Load(object sender, EventArgs e)
        {
            thread = 1;//starting threads
            threads = new List<ForumThread>();
            category = Request.QueryString["category"].ToString();
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from f_category where CategoryTitle='" + category + "' and ForumId=" + Session["forumid"];
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            cat = new ForumCategory();
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                cat.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                cat.CategoryTitle = rdr["CategoryTitle"].ToString();
                cat.SectionCount = Convert.ToInt32(rdr["SectionCount"]);
                cat.CreatorId = Convert.ToInt32(rdr["CreatorId"]);
                if (!(rdr["DateCreated"] == DBNull.Value))
                    cat.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                if (!(rdr["DateModified"] == DBNull.Value))
                    cat.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                cat.ForumId = Convert.ToInt32(Session["forumid"]);
                cat.published = 1;
                if (!(rdr["DatePublished"] == DBNull.Value))
                    cat.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
            }
            con1.Close();
            cat.GetPublishedSectionsFromDb();
            
        }
    }
}