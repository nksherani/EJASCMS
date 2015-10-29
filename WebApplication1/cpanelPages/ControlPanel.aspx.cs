using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.cpanelPages
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        public int posts, pages, categories, tags, comments, approvedcomments, unapprovedcomments, regusers, admins, moderators, editors;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select (select count (PostId) from Posts) as Posts, (select count(PageId) from Pages) as Pages,"+
"(select count(Id) from Categories) as Categories, (select count(distinct Tag) from Tags) as Tags,"+
"(select count(CommentId) from Comment) as Comments,(select count(CommentId) from Comment where Published = 1) as ApprovedComments,"+
"(select count(CommentId) from Comment where Published = 0) as UnApprovedComments,(select count(UserId) from login_v where Role = 'Registered User') as RegisteredUsers,"+
"(select count(UserId) from login_v where Role = 'Admin') as Admins,(select count(UserId) from login_v where Role = 'Moderator') as Moderators,"+
"(select count(UserId) from login_v where Role = 'Editor') as Editors";

            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                posts = Convert.ToInt32(rdr[0]);
                pages = Convert.ToInt32(rdr[1]);
                categories = Convert.ToInt32(rdr[2]);
                tags = Convert.ToInt32(rdr[3]);
                comments = Convert.ToInt32(rdr[4]);
                approvedcomments = Convert.ToInt32(rdr[5]);
                unapprovedcomments = Convert.ToInt32(rdr[6]);
                regusers = Convert.ToInt32(rdr[7]);
                admins = Convert.ToInt32(rdr[8]);
                moderators = Convert.ToInt32(rdr[9]);
                editors = Convert.ToInt32(rdr[10]);
            }
            con1.Close();
        }
    }
}