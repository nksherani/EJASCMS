using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.cs;
using System.Reflection;

namespace WebApplication1.MasterPages
{
    public partial class Pages : System.Web.UI.MasterPage
    {
        public static List<Category> categories;
        public static HttpCookie cookie=new HttpCookie("ejas_login");
        public string webiste_title, tagline, company,url, about,fb,twitter,github;
        public static List<Page_class> pages;
        public List<string> months = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = Category.GetAllCategoryNames();

            //display pages in navbar
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            pages = Page_class.ReadPagesFromDB();
            
            //check cookies for logged in user if any
            cookie = Request.Cookies["ejas_login"];
            if(cookie!=null)
            {
                lblHelloText.Text = "Hello "+cookie["username"];
                btnLoginb.Text = "Logout";
            }
            else
            {
                lblHelloText.Text = "Hello Guest";
                btnLoginb.Text = "Login";
            }
            
            //retrieving website title, tagline and company
            String q1 = "select * from websitedetails";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                webiste_title = rdr["WebsiteName"].ToString();
                tagline = rdr["tagline"].ToString();
                company = rdr["Company"].ToString();
                url = rdr["url"].ToString();
                about = rdr["about"].ToString();
                fb = rdr["FacebookPage"].ToString();
                twitter = rdr["TwitterTimeline"].ToString();
                github = rdr["Github"].ToString();
            }
            con1.Close();

            //retrieving archives months
            q1 = "select distinct CONVERT(CHAR(4), DateCreated, 100) + CONVERT(CHAR(4), DateCreated, 120) from posts";
            com1 = new SqlCommand(q1, con1);
            
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                months.Add(rdr[0].ToString());
            }
            con1.Close();
            if (IsPostBack)
                return;
            Plugin.LoadAssemblies();
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(cookie == null)
            {
                //toggle login control
                if (Login1.Visible)
                    Login1.Visible = false;
                else
                    Login1.Visible = true;
            }
            else
            {
                //logout
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                btnLoginb.Text = "Login";
                lblHelloText.Text = "Hello Guest";
                Session.Clear();
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            HttpCookie cookie = new HttpCookie("ejas_login");
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM login_v WHERE username='"+Login1.UserName+"' and password="+Login1.Password.GetHashCode().GetHashCode();
            SqlCommand com1 = new SqlCommand(q1, con1);
            int password = Login1.Password.GetHashCode().GetHashCode();
            con1.Open();
            SqlDataReader rdr;
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr["role"].ToString().ToLower().Equals("admin"))
                  Session["adminid"]= Convert.ToInt32(rdr["UserID"]);
                cookie["username"] = (rdr["Username"].ToString());
                cookie["userid"] = rdr["UserID"].ToString();
            }
            Response.Cookies.Add(cookie);
            con1.Close();
            if(Login1.RememberMeSet)
            cookie.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(cookie);
            btnLoginb.Text = "Logout";
            lblHelloText.Text = "Hello " + cookie["username"];
            Login1.Visible = false;

            //if (Convert.ToInt32(Session["adminid"])>0)
              // Response.Redirect("~/cpanelPages/ControlPanel.aspx");
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}