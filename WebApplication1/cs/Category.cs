using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.cs
{
    //this class corresponds to the Categories in which posts of blog are arranged
    public class Category
    {
        //Attributes of a category
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string parentName { get; set; }

        //constructors
        public Category(int id,string category,string parent)
        {
            categoryID = id;
            categoryName = category;
            parentName = parent;
        }
        public Category() { }

        //methods
        //Gets categoryId from database using categoryName
        public void GetCategoryId(string categoryName)
        {
            int id;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select id from categories where categoryname='" + categoryName + "'";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            id = Convert.ToInt32(com1.ExecuteScalar());
            con1.Close();
            categoryID= id;
        }

        // Get all category names
        public static List<Category> GetAllCategoryNames()
        {
            int id;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from categories";
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            List<Category> list = new List<Category>();
            Category category;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                category = new Category();
                category.categoryID = Convert.ToInt32(rdr[0]);
                category.categoryName = rdr[1].ToString();
                category.parentName = rdr[2].ToString();
                list.Add(category);
            }
            con1.Close();
            return list;
        }



    }
}
