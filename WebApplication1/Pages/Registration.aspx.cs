using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.cpanelPages
{
    public partial class Registration : System.Web.UI.Page
    {
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
        //public static int password;
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
        }

        protected void BtnDate_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
                
            }
            else
            {
                Calendar1.Visible = true;
                
            }
                
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string date = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtDob.Text = date;
            Calendar1.Visible = false;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CMSUser user = new CMSUser();
            if (TypedPassword == TypedPassword2)
            {
                user.FirstName = txtFName.Text;
                user.LastName = txtLName.Text;
                user.Username = txtUsername.Text;
                user.Password = TypedPassword.GetHashCode().GetHashCode();
                user.Role = "Registered User";
                user.DateOfBirth = Calendar1.SelectedDate;
                user.Email = txtEmail.Text;
                user.FacebookId = txtFacebook.Text;
                user.TwitterId = txtTwitter.Text;
                user.CreateUserinDb();
                lblConfrm.Text = "";
                Response.Redirect("home.aspx");
            }
            else
                lblConfrm.Text = "Passwords does not match";
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

        
    }
}