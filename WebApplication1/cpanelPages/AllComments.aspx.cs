using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.cpanelPages
{
    public partial class AllComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelected.Text = GridView1.SelectedRow.Cells[1].Text;
            txtCommentor.Text= GridView1.SelectedRow.Cells[6].Text;
            txtPostTitle.Text= GridView1.SelectedRow.Cells[5].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditComment.aspx?commentid=" + txtSelected.Text + "&commentor=" + txtCommentor.Text + "&posttitle=" + txtPostTitle.Text);
        }
    }
}