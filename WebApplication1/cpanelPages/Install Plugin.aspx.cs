using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.cs;


namespace WebApplication1.cpanelPages
{
    public partial class Install_Plugin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInstallPlugin_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                lblResponse.Text = "Please Select a File";
                lblResponse.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if(!(System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper()==".ZIP"))
                {
                    lblResponse.Text = "Selected file must be a zip archive";
                    lblResponse.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    FileUpload1.SaveAs(MapPath("~/temp/" + FileUpload1.FileName));
                    bool success = Plugin.ExtractPlugin(MapPath("~/temp/" + FileUpload1.FileName),FileUpload1.FileName);
                    try
                    {
                        System.IO.File.Delete(MapPath("~/temp/" + FileUpload1.FileName));
                    }
                    catch (Exception ex)
                    {
                        lblResponse2.Text=("Something went wrong while deleting temporary files.<br/>");
                        lblResponse2.ForeColor = System.Drawing.Color.Red;
                    }
                    if (success)
                    {
                        Plugin.SaveAssemblies(MapPath("~/Plugins/" + FileUpload1.FileName.Replace(".", "_") + "/bin"), FileUpload1.FileName);
                        
                        Plugin plugin = new Plugin(FileUpload1.FileName);
                        plugin.Read_Author_About();
                        plugin.SavePluginDatatoDB();
                        lblResponse.Text = "Plugin Installed";
                        lblResponse.ForeColor = System.Drawing.Color.Green;
                        Button1.Visible = true;
                    }                    
                }
                
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllPlugins.aspx");
        }
    }
}