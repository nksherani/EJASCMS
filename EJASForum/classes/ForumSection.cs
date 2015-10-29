using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EJASForum.classes
{
    public class ForumSection
    {
        public int SectionId;
        public string SectionTitle;
        public int? ThreadCount;
        public DateTime? DateCreated;
        public DateTime? DateModified;
        public int? CreatorId;
        public int? CategoryId;
        public int? published;
        public DateTime? DatePublished;
        

        public ForumSection()
        {
            SectionId = 0;
            SectionTitle = "Title";
            ThreadCount = null;
            DateCreated = null;
            DateModified = null;
            CreatorId = null;
            CategoryId = null;
            published = 0;
            DatePublished = null;
        }
        public ForumSection(ForumSection sec)
        {
            SectionId = sec.SectionId;
            SectionTitle = sec.SectionTitle;
            ThreadCount = sec.ThreadCount;
            DateCreated = sec.DateCreated;
            DateModified = sec.DateModified;
            CreatorId = sec.CreatorId;
            CategoryId = sec.CategoryId;
            published = sec.published;
            DatePublished = sec.DatePublished;
        }

        public List<ForumThread> GetNThreads(int initial,int length)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM f_Thread where published=1 and SectionId = "+this.SectionId+" order by DateCreated";
            SqlDataReader rdr;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            rdr=com1.ExecuteReader();
            ForumThread thread;
            List<ForumThread> NThreads= new List<ForumThread>();
            int n=1;
            while (rdr.Read())
            {
                //NThreads = new List<ForumThread>();
                thread = new ForumThread();
                thread.ThreadID = Convert.ToInt32(rdr["ThreadID"]);
                thread.ThreadTitle = rdr["ThreadTitle"].ToString();
                //thread.ThreadBody = rdr["ThreadBody"].ToString();
                thread.SectionId = Convert.ToInt32(rdr["SectionID"]);
                thread.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                thread.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                thread.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                thread.Published = 1;
                thread.CreatorId = Convert.ToInt32(rdr["CreatorId"]);
                if(n >= initial && n <= initial+length-1)//improve efficiency
                NThreads.Add(thread);
                n++;
            }
            con1.Close();
            return NThreads;
        }
    }
}
