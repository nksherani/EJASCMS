using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.Pages
{
    public partial class MyProfile : System.Web.UI.Page
    {
        public static int userid = 0;
        public static CMSUser user;
        protected const string PasswordMask = "*********************************************************************************************************************************";
        protected string TypedPassword
        {
            get
            {
                if (ViewState["TypedPassword"] != null)
                {
                    return Convert.ToString(ViewState["TypedPassword"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedPassword"] = value;
            }
        }
        protected string TypedPassword2
        {
            get
            {
                if (ViewState["TypedPassword2"] != null)
                {
                    return Convert.ToString(ViewState["TypedPassword2"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedPassword2"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //detect if password was changed. if filled and not equal to mask, it is new
            if (txtPassword.Text.Trim().Length > 0 && txtPassword.Text != PasswordMask)
            {
                TypedPassword = txtPassword.Text;
                txtPassword.Attributes.Add("value", PasswordMask);
                TypedPassword2 = txtConfirmPassword.Text;
                txtConfirmPassword.Attributes.Add("value", PasswordMask);
            }
            txtPassword.Attributes.Add("onclick", "Clear_Password('" + txtPassword.ClientID + "')");
            txtConfirmPassword.Attributes.Add("onclick", "Clear_Password('" + txtConfirmPassword.ClientID + "')");

            if (!ClientScript.IsClientScriptBlockRegistered("Clear_Password"))
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "Clear_Password", "function Clear_Password(id){ try{document.getElementById(id).value = '';} catch(ex){/* do nothing */} }", true);
            }
            if (IsPostBack)
                return;
            HttpCookie cookie = Request.Cookies["ejas_login"];
            
            if (cookie != null)
            {
                userid = Convert.ToInt32(cookie["userid"]);
                //btnLoginb.Text = "Logout";
            }
            user=new CMSUser();
            user.GetUserbyId(userid);
            txtUsername.Text = user.Username;
            txtFName.Text = user.FirstName;
            txtLName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtFacebook.Text = user.FacebookId;
            txtTwitter.Text = user.TwitterId;
            txtDob.Text = user.DateOfBirth.ToString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string date = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtDob.Text = date;
            Calendar1.Visible = false;
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
                lblUsernameAvailable.Visible = true;
            if (CMSUser.IsUsernameAvailable(txtUsername.Text))
                lblUsernameAvailable.Text = "Username is available";
            else
                lblUsernameAvailable.Text = "Username is not available";
            return;
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (TypedPassword == TypedPassword2 || string.IsNullOrEmpty(txtPassword.Text))
            {
                user.FirstName = txtFName.Text;
                user.LastName = txtLName.Text;
                user.Email = txtEmail.Text;
                user.FacebookId = txtFacebook.Text;
                user.TwitterId = txtTwitter.Text;
                user.DateOfBirth = Calendar1.SelectedDate;
                user.UpdateProfilebyUser(userid);
                if(!string.IsNullOrEmpty(TypedPassword))
                {
                    if (TypedPassword == TypedPassword2)
                    {
                        //changing password
                        lblConfrm.Text = "";
                        user.UpdatePasswordbyUser(userid, TypedPassword);
                    }
                    else
                    {
                        lblConfrm.Text = "Passwords must match";
                        return;
                    }
                }
                Response.Redirect("home.aspx");
            }
            else
                lblConfrm.Text = "Passwords must match";
        }

        protected void BtnDate_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
                Calendar1.Visible = false;
            else
                Calendar1.Visible = true;
        }
    }
}