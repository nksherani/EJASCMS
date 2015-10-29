using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.cpanelPages
{
    public partial class EditComment : System.Web.UI.Page
    {
        public static Comment comment;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
                return;
            int commentid = Convert.ToInt32(Request.QueryString["commentid"]);
            string posttitle = Request.QueryString["posttitle"];
            string commentor = Request.QueryString["commentor"];
            comment = new Comment(commentid);
            txtComment.Text = comment.CommentBody;
            lblPostTitle.Text = posttitle;
            lblCommentor.Text = commentor;
            lblDateTime.Text = comment.DateModified.ToString();
            if (comment.Published == 1)
                DropDownList1.SelectedIndex = 0;
            else
                DropDownList1.SelectedIndex = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
                comment.Published = 1;
            else
                comment.Published = 0;
            
            comment.CommentBody = txtComment.Text;
            comment.UpdateComment();
            lblSuccess.Text = "Comment Updated Successfully";
            lblSuccess.ForeColor = System.Drawing.Color.Green;
        }
    }
}