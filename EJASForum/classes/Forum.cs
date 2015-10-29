using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EJASForum.classes
{
    public class Forum
    {
        public int ForumId;
        public string ForumTitle;
        public int? CategoryCount;
        public Nullable<DateTime> DateCreated;
        public int? CreatorId;
        public int? Published;
        public List<ForumCategory> CategoryList;

        public Forum()
        {
            GetForumDetails();
            CategoryList = new List<ForumCategory>();
            GetPublishedCategoriesFromDb();
        }
        public void GetForumDetails()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM f_forumdetails where Published=1";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                ForumId = Convert.ToInt32(rdr["ForumId"]);
                ForumTitle = rdr["ForumTitle"].ToString();
                CategoryCount = Convert.ToInt32(rdr["CategoryCount"]);
                if(!(rdr["DateCreated"]==DBNull.Value))
                    DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                CreatorId = Convert.ToInt32(rdr["CreatorId"]);
            }
            con1.Close();
        }
        
        public void GetPublishedCategoriesFromDb()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM f_category where Published=1 AND ForumId=" + this.ForumId;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            ForumCategory cat;
            while (rdr.Read())
            {
                cat = new ForumCategory();
                cat.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                cat.CategoryTitle = rdr["CategoryTitle"].ToString();
                cat.SectionCount = Convert.ToInt32(rdr["SectionCount"]);
                cat.CreatorId = Convert.ToInt32(rdr["CreatorId"]);
                if (!(rdr["DateCreated"] == DBNull.Value))
                    cat.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                if (!(rdr["DateModified"] == DBNull.Value))
                    cat.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                cat.ForumId = this.ForumId;
                cat.published = 1;
                if (!(rdr["DatePublished"] == DBNull.Value))
                    cat.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                cat.GetPublishedSectionsFromDb();
                CategoryList.Add(cat);
            }
            con1.Close();
        }

    }
}
