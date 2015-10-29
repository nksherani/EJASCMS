using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.cs
{
    public class Tag
    {
        public int postid { get; set; }
        public string tag { get; set; }
        public Tag(string _tag,int _postid)
        {
            tag = _tag;
            postid = _postid;
        }
        public void saveTagtoDb()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);

            string q1;
            q1 = "INSERT INTO TAGS(tag,pagepostid) values('" + this.tag + "'," + postid + ")";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

        }
        //delete tags
        public void DeleteTags()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1;
            q1 = "Delete from TAGSwhere postid="  + postid ;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

        }
    }
}