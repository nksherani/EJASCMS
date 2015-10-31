using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        DateTime dob;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            if (Convert.ToInt32(Session["userid"]) > 0)
                Response.Redirect("home.aspx");
            if(Request.QueryString["error"]!=null)
            {
                Response.Write("<h3>You Must Be Logged In To Perform this Task");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ForumUser user = new ForumUser();
            user.FirstName = txtFName.Text;
            user.LastName = txtFName.Text;
            user.Username = txtUsername.Text;
            if (Convert.ToInt32(Session["pwd"]) == 0)
                user.Password = txtPassword.Text.GetHashCode().GetHashCode();
            else
                user.Password = Convert.ToInt32(Session["pwd"]);
            user.Role = "Registered User";
            user.DateOfBirth = Calendar1.SelectedDate;
            user.Email = txtEmail.Text;
            user.FacebookId = txtFacebook.Text;
            user.TwitterId = txtTwitter.Text;
            user.CreateUserinDb();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["pwd"] = txtPassword.Text.GetHashCode().GetHashCode();
            if (Calendar1.Visible)
                Calendar1.Visible = false;
            else
                Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            dob = Calendar1.SelectedDate;
            Calendar1.Visible = false;
        }
    }
}