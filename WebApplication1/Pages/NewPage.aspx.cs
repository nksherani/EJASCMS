using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string q1 = "SELECT stylesheet FROM themES WHERE state='Active'";
            string StyleSheet = "";
            con1.Open();
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
                StyleSheet = rdr["StyleSheet"].ToString();
            con1.Close();
            //string q = "/css/" + StyleSheet;
            MyStyleSheet.Attributes.Add("href", "/css/"+ StyleSheet);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string trim = Regex.Replace(TextBox1.Text, @"\s", "");
            string sb1 = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + trim +
                ".aspx.cs\" Inherits=\"ENaveed." + trim + "\" %>";
            string sb2 = "<!DOCTYPE html>";
            string sb3 = "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            string sb4 = "<head runat=\"server\">" + "<title></title>" + "</head>" + "<body>" + "<form id=\"form1\" runat=\"server\">";
            string content = ASPxHtmlEditor1.Html;
            string sb5 = "</form>" + "</body>" + "</html>";
            string[] html = { sb1, sb2, sb3, sb4, content, sb5 };

            string[] cs = { "using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Web;",
                "using System.Web.UI;", "using System.Web.UI.WebControls;","namespace ENaveed","{",
                "public partial class "+trim+": System.Web.UI.Page","{",
                "protected void Page_Load(object sender, EventArgs e)","{","}","}","}" };

            File.WriteAllLines(Server.MapPath("" + trim + ".aspx"), html);
            File.WriteAllLines(Server.MapPath("" + trim + ".aspx.cs"), cs);
            Response.Write("page created");
            Response.Redirect("" + trim + ".aspx");
        }
    }
}