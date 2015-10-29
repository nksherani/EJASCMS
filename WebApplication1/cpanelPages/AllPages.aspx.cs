using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.cpanelPages
{
    public partial class AllPages : System.Web.UI.Page
    {
        public String pagename;
        public string pageid;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drpActions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageid = GridView1.SelectedRow.Cells[1].Text;
            txtSelected.Text = pageid;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpActions.SelectedValue == "Edit in Full Editor") ;
            Response.Redirect("EditPage.aspx?pageid=" + txtSelected.Text);
        }

        protected void GridView1_RowDeleted1(object sender, GridViewDeletedEventArgs e)
        {
            File.Delete(MapPath("~/UserPages/" + pagename.Replace("'","") + ".aspx"));
            File.Delete(MapPath("~/UserPages/" + pagename.Replace("'", "") + ".aspx.cs"));
            
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            pagename = row.Cells[2].Text;
            pageid = row.Cells[1].Text;


        }
        
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        
    }
}