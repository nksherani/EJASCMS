using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.cs
{
    public class PostCategory
    {
        int postid { get; set; }
        Category category { get; set; }
        public PostCategory(int _postid,Category _category)
        {
            postid = _postid;
            category = _category;
        }

        public static void DeleteCatecoriesofPost(int postid)
        {
            string q1 = "delete from postcategories where postid=" + postid ;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
        public void PostCategorySave()
        {
            string q1 = "insert into postcategories values(" + postid + "," + category.categoryID + ")";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
}
