using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;

namespace WebApplication1.cpanelPages
{
    public partial class AllPlugins : System.Web.UI.Page
    {
        public static int toggle;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            toggle = 0;
        }
        public string Activated(int activated)
        {
            if (activated == 0)
                return "No";
            else
                return "Yes";
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (((DropDownList)GridView1.Rows[GridView1.EditIndex].Cells[3].FindControl("DropDownList1")).SelectedIndex == 0)
            {
                SqlDataSource1.UpdateParameters["Activated"].DefaultValue = 1.ToString();
                
            }
            else
                SqlDataSource1.UpdateParameters["Activated"].DefaultValue = 0.ToString();
            
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (((DropDownList)GridView1.Rows[GridView1.EditIndex].Cells[3].FindControl("DropDownList1")).SelectedIndex == 0)
            {
                if(!(toggle % 2 == 0))
                {

                    //run default page of plugin
                    int index = GridView1.EditIndex;
                    GridViewRow row = GridView1.Rows[index];
                    TextBox lblfilename = (TextBox)row.Cells[2].FindControl("TextBox1");
                    string filename = lblfilename.Text;
                    var path = "../Plugins/" + filename.Replace(".", "_") + "/Default.aspx";
                    Response.Redirect(path);

                }
            }
            else
            {
                if (!(toggle % 2 == 0))
                {
                    //deactivate plugin
                    int index = GridView1.EditIndex;
                    GridViewRow row = GridView1.Rows[index];
                    TextBox lblfilename = (TextBox)row.Cells[2].FindControl("TextBox1");
                    string filename = lblfilename.Text;
                    string folder = filename.Replace(".", "_");//passed to uninstall page
                    string pageurl = "../Plugins/" + filename.Replace(".", "_") + "/Pages/home.aspx";
                    string path = "~/Plugins/" + filename.Replace(".", "_") + "/Deactivate.aspx";//?dir="+folder+"&task=deactivate&pageurl="+pageurl;
                    HttpCookie cookie = new HttpCookie("plugin");
                    cookie.Values.Add("folder", folder);
                    cookie.Values.Add("pageurl", pageurl);
                    Response.Cookies.Add(cookie);
                    Response.Redirect(string.Format(path));
                }
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggle++;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //delete and uninstall plugin
            int index = Convert.ToInt32(txtIndex.Text);
            GridViewRow row = GridView1.Rows[index];
            Label lblfilename = (Label)row.Cells[2].FindControl("Label2");
            string filename = lblfilename.Text;
            string folder = filename.Replace(".", "_");//passed to uninstall page
            //string pageurl = "../Plugins/" + folder + "/Pages/home.aspx";
            string path1 = HttpContext.Current.Server.MapPath("../Plugins/" + folder);

            if (Plugin.PluginStatus(filename) == 0)
            {
                Plugin.DeleteDirectory(path1);
                Plugin.DeletePluginfromDB(filename);
                lblStatus.Text=("Plugin uninstalled successfully");
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = ("Please deactivate your plugin first");
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIndex.Text = GridView1.SelectedIndex.ToString();
        }

        
    }
}