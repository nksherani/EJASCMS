using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EJASForum.classes
{
    public class ForumCategory
    {
        public int CategoryId;
        public string CategoryTitle;
        public int? SectionCount;
        public int? CreatorId;
        public DateTime? DateCreated;
        public DateTime? DateModified;
        public int? ForumId;
        public DateTime? DatePublished;
        public int? published;
        public List<ForumSection> SectionList;
        public string Description;

        // empty constructor
        public ForumCategory()
        {
            SectionList = new List<ForumSection>();
        }

        //parameterized constructors
        public ForumCategory(string title,int creator,int _published,int forumid,string desc)
        {
            SectionList = new List<ForumSection>();
            //CategoryId=creator;
            CategoryTitle=title;
            SectionCount=0;
            CreatorId=creator;
            DateCreated=DateTime.Now;
            DateModified=DateTime.Now;
            ForumId=forumid;
            published = _published;
            if(published==1)
            DatePublished=DateTime.Now;
            Description=desc;    
        }

        public ForumCategory(string title, int creator, int _published, int forumid)
        {
            SectionList = new List<ForumSection>();
            //CategoryId=creator;
            CategoryTitle = title;
            SectionCount = 0;
            CreatorId = creator;
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            ForumId = forumid;
            published = _published;
            if (published == 1)
                DatePublished = DateTime.Now;
            
        }

        //populate sectionlist attribute from db
        public void GetPublishedSectionsFromDb()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM f_section where Published=1 AND CategoryId=" + this.CategoryId;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            ForumSection sec;
            while (rdr.Read())
            {
                sec = new ForumSection();
                sec.SectionId = Convert.ToInt32(rdr["SectionId"]);
                sec.SectionTitle = rdr["SectionTitle"].ToString();
                sec.ThreadCount = Convert.ToInt32(rdr["ThreadCount"]);
                if (!(rdr["DateCreated"] == DBNull.Value))
                    sec.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                if (!(rdr["DateModified"] == DBNull.Value))
                    sec.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                sec.CategoryId = this.CategoryId;
                sec.published = 1;
                if (!(rdr["DatePublished"] == DBNull.Value))
                    sec.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                if (!(rdr["CreatorID"] == DBNull.Value))
                    sec.CreatorId = Convert.ToInt32(rdr["CreatorID"]);
                SectionList.Add(new ForumSection(sec));
            }
            con1.Close();
        }

        //create category into db
        public void CreateCategoryintoDb()
        {
            string q1="insert into f_category values(@title,0,@creator,@dtc,@dtm,@forumid,@published,@dtp,@desc)";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@title", CategoryTitle);
            com1.Parameters.AddWithValue("@creator", CreatorId);
            com1.Parameters.AddWithValue("@dtc", DateCreated);
            com1.Parameters.AddWithValue("@dtm", DateModified);
            com1.Parameters.AddWithValue("@published", published);
            if(published==1)
                com1.Parameters.AddWithValue("@dtp", DatePublished);
            else
                com1.Parameters.AddWithValue("@dtp", DBNull.Value);
            if (!string.IsNullOrEmpty(Description))
                com1.Parameters.AddWithValue("@desc", Description);
            else
                com1.Parameters.AddWithValue("@desc", DBNull.Value);
            com1.Parameters.AddWithValue("@forumid", ForumId);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }

        //get all categories from db
        public static List<string> GetPublishedCategoryNames(int forumid)
        {
            string q1 = "select CategoryTitle from f_category where Published=1 and ForumId=" + forumid;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            List<string> catlist = new List<string>();
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                catlist.Add(rdr[0].ToString());
            }
            con1.Close();
            return catlist;
        }

    }
}
