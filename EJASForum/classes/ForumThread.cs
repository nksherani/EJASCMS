using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace EJASForum.classes
{
    public class ForumThread
    {
        public int ThreadID;
        public string ThreadTitle;
        public string ThreadBody;
        public int? SectionId;
        public DateTime? DateCreated;
        public DateTime? DateModified;
        public int? Published;
        public int? CreatorId;
        public string Author;
        public DateTime? DatePublished;

        public void getAuthor()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT FirstName,LastName from Profiles where id=" + this.CreatorId;
            SqlCommand com1 = new SqlCommand(q1,con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                Author = rdr["FirstName"].ToString() +" "+ rdr["LastName"].ToString();
            }
            con1.Close();
        }

        public void GetThread(int threadid)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from f_Thread where ThreadId=" + threadid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                ThreadID = Convert.ToInt32(rdr["ThreadId"]);
                ThreadTitle = rdr["ThreadTitle"].ToString();
                ThreadBody = rdr["ThreadBody"].ToString();
                SectionId = Convert.ToInt32(rdr["SectionId"]);
                DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                DateModified = Convert.ToDateTime(rdr["DateModified"]);
                DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                Published = Convert.ToInt32(rdr["Published"]);
                CreatorId = Convert.ToInt32(rdr["CreatorId"]);
            }
            con1.Close();
        }

        public List<ForumReply> GetNReplies(int initial, int length)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM Reply_Profile_view where published=1 and ThreadId = " + this.ThreadID+" order by DateCreated";
            SqlDataReader rdr;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            rdr = com1.ExecuteReader();
            ForumReply Reply;
            List<ForumReply> NReplies = new List<ForumReply>();
            int n = 1;
            while (rdr.Read())
            {
                //NThreads = new List<ForumThread>();
                Reply = new ForumReply();
                Reply.ThreadId = Convert.ToInt32(rdr["ThreadId"]);
                Reply.ReplyId = Convert.ToInt32(rdr["ReplyId"]);
                Reply.ReplyBody = rdr["ReplyBody"].ToString();
                Reply.Replier = rdr["Replier"].ToString();
                Reply.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                Reply.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                Reply.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                Reply.Published = 1;
                Reply.ReplierId = Convert.ToInt32(rdr["ReplierId"]);
                if (n >= initial && n <= initial + length - 1)//improve efficiency
                    NReplies.Add(Reply);
                n++;
            }
            con1.Close();
            return NReplies;
        }

        public void PostReply(string reply)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1="INSERT INTO f_reply values("+ThreadID+",'"+reply+"',"+ HttpContext.Current.Session["userid"] +",@dt,@dt,1,@dt)";
            SqlCommand com1 = new SqlCommand(q1,con1);
            com1.Parameters.AddWithValue("@dt", DateTime.Now);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
}