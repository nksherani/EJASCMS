using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EJASForum.classes
{
    public class ForumUser
    {
        public string FirstName;
        public string LastName;
        public string Username;
        public int Password;
        public string Role;
        public DateTime? DateOfBirth;
        public string Email,FacebookId,TwitterId;

        public ForumUser()
        {

        }
        

        public void CreateUserinDb()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "insert into Login values('" + Username + "','" + Password + "');";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            //insert into profiles
            q1 = "insert into profiles values(@fn,@ln,@role,@dob,@email,@fb,@twitter)";
            com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@fn",FirstName);
            com1.Parameters.AddWithValue("@ln", LastName);
            com1.Parameters.AddWithValue("@role", Role);
            com1.Parameters.AddWithValue("@dob", DateOfBirth);
            com1.Parameters.AddWithValue("@email", Email);
            com1.Parameters.AddWithValue("@fb", FacebookId);
            com1.Parameters.AddWithValue("@twitter", TwitterId);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
}
