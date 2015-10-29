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
    public partial class SectionView : System.Web.UI.Page
    {
        public List<ForumThread> NThreads;
        public int thread;
        public string forumtitle;
        public string category;
        public string section;
        public int sectionid;
        public ForumSection sec;
        protected void Page_Load(object sender, EventArgs e)
        {
            thread = Convert.ToInt32(Request.QueryString["thread"]);
            NThreads = new List<ForumThread>();
            forumtitle = Request.QueryString["forum"];
            category = Request.QueryString["category"];
            section = Request.QueryString["section"];
            sectionid = Convert.ToInt32(Request.QueryString["sectionid"]);
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM f_section where published=1 and SectionId="+sectionid; ;
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            sec = new ForumSection();
            //ForumThread thread = new ForumThread();
            con1.Open();
            rdr = com1.ExecuteReader();
            
            while(rdr.Read())
            {
                sec = new ForumSection();
                sec.SectionId = Convert.ToInt32(rdr["SectionId"]);
                sec.SectionTitle = rdr["SectionTitle"].ToString();
                sec.ThreadCount = Convert.ToInt32(rdr["ThreadCount"]);
                if (!(rdr["DateCreated"] == DBNull.Value))
                    sec.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                if (!(rdr["DateModified"] == DBNull.Value))
                    sec.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                //sec.CategoryId = this.CategoryId;
                sec.published = 1;
                if (!(rdr["DatePublished"] == DBNull.Value))
                    sec.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                if (!(rdr["CreatorID"] == DBNull.Value))
                    sec.CreatorId = Convert.ToInt32(rdr["CreatorID"]);
                NThreads = sec.GetNThreads(thread, 30);
            }
            con1.Close();
            
        }
    }
}