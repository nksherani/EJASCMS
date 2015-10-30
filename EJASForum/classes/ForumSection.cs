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
        public string Description;
        

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
            Description = "";
        }

        //parametrized constructors
        public ForumSection(string title,int creator,string cat,int _published,string desc)
        {
            string q1 = "select CategoryId from f_category where CategoryTitle='" + cat+"'";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1,con1);
            SectionTitle = title;
            ThreadCount = 0;
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            CreatorId = creator;
            con1.Open();
            CategoryId = Convert.ToInt32(com1.ExecuteScalar());
            con1.Close();
            published = _published;
            if(published==1)
                DatePublished = DateTime.Now;
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
                thread.ThreadBody = rdr["ThreadBody"].ToString();
                if (thread.ThreadBody.Length > 200)
                {
                    thread.ThreadBody = thread.ThreadBody.Substring(0, 200);
                    thread.ThreadBody += "...";
                } 
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

        //create category into db
        public void CreateSectionintoDb()
        {
            string q1 = "insert into f_section values(@title,0,@dtc,@dtm,@creator,@catid,@published,@dtp,@desc)";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@title", SectionTitle);
            com1.Parameters.AddWithValue("@creator", CreatorId);
            com1.Parameters.AddWithValue("@dtc", DateCreated);
            com1.Parameters.AddWithValue("@dtm", DateModified);
            com1.Parameters.AddWithValue("@published", published);
            if (published == 1)
                com1.Parameters.AddWithValue("@dtp", DatePublished);
            else
                com1.Parameters.AddWithValue("@dtp", DBNull.Value);
            if (!string.IsNullOrEmpty(Description))
                com1.Parameters.AddWithValue("@desc", Description);
            else
                com1.Parameters.AddWithValue("@desc", DBNull.Value);
            com1.Parameters.AddWithValue("@catid", CategoryId);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }

        //get all sections from db
        public static List<string> GetAllSectionNames(string category)
        {
            string q1 = "select SectionTitle from f_section where CategoryId=(select CategoryId from f_category where CategoryTitle='"+category+"')";
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
