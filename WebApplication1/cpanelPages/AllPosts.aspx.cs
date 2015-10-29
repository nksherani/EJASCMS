using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.cpanelPages
{
    public partial class AllPosts1 : System.Web.UI.Page
    {
        public string postid;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (IsPostBack)
             //   return;
        }

        protected void drpActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpActions.SelectedValue == "Edit in Full Editor");
            Response.Redirect("EditPost.aspx?postid="+txtSelected.Text);        
            
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            postid = GridView1.SelectedRow.Cells[1].Text;
            txtSelected.Text = postid;
        }
        
    }
}