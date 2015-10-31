using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJASForum.classes;
using System.Data.SqlClient;
using System.Configuration;


namespace EJASForum
{
    public partial class forum : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from f_forumdetails where Published=1";
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                Session["forumid"] = rdr["ForumId"];
                Session["forumtitle"] = rdr["ForumTitle"];
            }

            con1.Close();
            HttpCookie cookie = Request.Cookies["ejas_login"];
            if(cookie!=null)
            {
                Session["userid"] = cookie["userid"];
                btnShowLogin.Text = "Logout";
                lblHelloText.Text = "Hello "+cookie["username"].ToString();
            }
        }

        protected void btnShowLogin_Click(object sender, EventArgs e)
        {
            if (!(Convert.ToInt32(Session["userid"]) > 0))
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
                Session.RemoveAll();
                Session.Clear();
                //btnAdmin.Visible = false;
                btnShowLogin.Text = "Login";
                lblHelloText.Text = "Hello Guest";
                HttpCookie cookie = Request.Cookies["ejas_login"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                    
                }
                Response.Redirect("../Pages/home.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);

            string q1 = "SELECT * FROM login_v WHERE username='" + Login1.UserName + "' and password=" + Login1.Password.GetHashCode().GetHashCode();
            SqlCommand com1 = new SqlCommand(q1, con1);
            int password = Login1.Password.GetHashCode().GetHashCode();
            con1.Open();
            SqlDataReader rdr;
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr["role"].ToString().ToLower().Equals("admin"))
                    Session["admin"] = true;
                Session["userid"] = Convert.ToInt16(rdr["UserID"]);
                Session["username"] = (rdr["Username"].ToString());
            }
            con1.Close();
            if (Convert.ToInt32(Session["userid"]) > 0)
            {
                HttpCookie cookie = new HttpCookie("ejas_login");
                cookie["username"] = Session["username"].ToString();
                cookie["userid"] = Session["userid"].ToString();
                if (Login1.RememberMeSet)
                    cookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(cookie);
                btnShowLogin.Text = "Logout";
                Login1.Visible = false;
                if (Convert.ToBoolean(Session["admin"]))
                {
                    Response.Redirect("../Pages/home.aspx");
                    //btnAdmin.Visible = true;
                }
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CPanel/CpanelMain.aspx");
        }
    }
}