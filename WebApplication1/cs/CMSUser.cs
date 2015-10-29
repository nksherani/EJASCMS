using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.cs
{
    //this class corresponds to the users which are registered, admins, moderators, editors
    public class CMSUser
    {
        //Attributes of a user/person 
        public string FirstName;
        public string LastName;
        public string Username;
        public int Password;
        public string Role;
        public DateTime? DateOfBirth;
        public string Email, FacebookId, TwitterId;

        //constructor
        public CMSUser()
        {

        }
        
        //check availability of username
        public static bool IsUsernameAvailable(string username)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select username from login";
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr=com1.ExecuteReader();
            while (rdr.Read())
            {
                if (username.ToLower() == rdr[0].ToString().ToLower())
                    return false;
            }
            con1.Close();
            return true;
        }
        //create/save object of this class into database
        public void CreateUserinDb()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "insert into Login values('" + Username + "','" + Password + "');";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            q1 = "insert into profiles values(@fn,@ln,@role,@dob,@email,@fb,@twitter)";
            com1 = new SqlCommand(q1, con1);
            //adding parameters
            com1.Parameters.AddWithValue("@fn", FirstName);
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

        //load user from db
        public void GetUserbyId(int id)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select P.*,L.* from Profiles P, Login L where L.UserId=P.Id and Id=" + id;
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                Username = rdr["Username"].ToString();
                FirstName = rdr["FirstName"].ToString();
                LastName = rdr["LastName"].ToString();
                Role = rdr["Role"].ToString();
                DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                Email = rdr["Email"].ToString();
                FacebookId = rdr["FacebookId"].ToString();
                TwitterId = rdr["TwitterId"].ToString();

            }
            con1.Close();
            
        }

        //update user profile by user
        public void UpdateProfilebyUser(int userid)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "Update profiles set Firstname=@fn, LastName=@ln,DateOfBirth=@dob, Email=@email,FacebookId=@fb,TwitterId=@twitter where Id="+userid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1 = new SqlCommand(q1, con1);
            //adding parameters
            com1.Parameters.AddWithValue("@fn", FirstName);
            com1.Parameters.AddWithValue("@ln", LastName);
            com1.Parameters.AddWithValue("@dob", DateOfBirth);
            com1.Parameters.AddWithValue("@email", Email);
            com1.Parameters.AddWithValue("@fb", FacebookId);
            com1.Parameters.AddWithValue("@twitter", TwitterId);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }

        //update password by user
        public void UpdatePasswordbyUser(int userid,string password)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "Update login set Password=@password where UserId="+userid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1 = new SqlCommand(q1, con1);
            //adding parameters
            com1.Parameters.AddWithValue("@password", password.GetHashCode().GetHashCode());
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
}
