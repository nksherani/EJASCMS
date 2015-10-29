using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ForumCategory()
        {
            SectionList = new List<ForumSection>();
        }
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
    }
}
