using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.cs
{
    //this class corresponds to comments below blog-posts
    public class Comment
    {
        //attributes
        public int CommentId;
        public int CommentorId;
        public string Commentor;
        public int PostId;
        public string CommentBody;
        public DateTime DateCreated;
        public DateTime DateModified;
        public DateTime DatePublished;
        public int Published;

        //constructor
        public Comment()
        {

        }

        //get constructor
        public Comment(int id)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from Comment where CommentId=" + id;
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                CommentId = id;
                PostId = Convert.ToInt32(rdr["PostId"]);
                CommentBody = rdr["CommentBody"].ToString();
                CommentorId = Convert.ToInt32(rdr["CommentorId"]);
                DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                DateModified = Convert.ToDateTime(rdr["DateModified"]);
                Published = Convert.ToInt32(rdr["Published"]);
                if(Published==1)
                    DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
            }
            con1.Close();
        }

        //update comment
        public void UpdateComment()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "UPDATE Comment set CommentBody=@cb, DateModified=@dt, Published=@published";
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dt", DateTime.Now);
            com1.Parameters.AddWithValue("@published", Published);
            com1.Parameters.AddWithValue("@cb", CommentBody);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
}