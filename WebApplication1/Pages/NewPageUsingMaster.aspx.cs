using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class NewPageUsingMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string trim = Regex.Replace(TextBox1.Text, @"\s", "");
            string header = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + trim +
                ".aspx.cs\" Inherits=\"ENaveed." + trim + "\" %>";
            string head = "<asp:Content ContentPlaceHolderID=\"head\" runat=\"server\">";
            string body = "<asp:Content ContentPlaceHolderID=\"body\" runat=\"server\">";
            string closingTag = "</asp:Content>";
            string title = TextBox1.Text;
            string content = ASPxHtmlEditor1.Html;
            string[] html = { header, head, title, closingTag,body , content, closingTag };
            //We can put option to select masterpage layout for each page
            string[] cs = { "using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Web;",
                "using System.Web.UI;", "using System.Web.UI.WebControls;","namespace ENaveed","{",
                "public partial class "+trim+": System.Web.UI.Page","{",
                "void Page_PreInit(Object sender, EventArgs e)","{","this.MasterPageFile = \"~/MasterPages/Pages.Master\";","}",
            "protected void Page_Load(object sender, EventArgs e)","{","}","}","}" };

            File.WriteAllLines(Server.MapPath("" + trim + ".aspx"), html);
            File.WriteAllLines(Server.MapPath("" + trim + ".aspx.cs"), cs);

            //saving page meta data in db

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "INSERT INTO PAGES(PageName,DateCreated) values('" + trim + "','" + DateTime.Now + "')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

            Response.Write("page created");
            Response.Redirect("" + trim + ".aspx");
            
        }
    }
}