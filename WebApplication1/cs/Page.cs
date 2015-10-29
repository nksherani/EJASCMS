using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.cs
{
    //represents pages of blog
    public class Page_class
    {
        public int pageId { get; set; }
        public string pageURL { get; set; }
        //name of aspx file
        public string pageName { get; set; }

        //name displayed at the top of the page
        public string displayName { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        //1=>published; 0=>Not published
        public int? published { get; set; }
        public DateTime? datePublished { get; set; }
        public int? authorId { get; set; }

        //page link
        string PageURL { get; set; }

        //write constructurs
        public Page_class(string _displayName, int _published)
        {
            SetPageID();
            pageName = Regex.Replace(_displayName, @"\s", "");
            displayName = _displayName;
            dateCreated = dateModified = DateTime.Now;
            published = _published;
            if (published == 1)
                datePublished = DateTime.Now;
            authorId = Convert.ToInt32(HttpContext.Current.Session["adminid"]);
        }

        public Page_class() { }

        //read pages from db function
        public static List<Page_class> ReadPagesFromDB()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from pages where published=1";
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            Page_class page;
            List<Page_class> pages = new List<Page_class>();
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                page = new Page_class();
                page.pageId = Convert.ToInt32(rdr["PageID"]);
                page.pageName = rdr["PageName"].ToString();
                page.displayName = rdr["DisplayName"].ToString();
                page.pageURL = rdr["pageURL"].ToString();
                if(rdr["DateCreated"] != DBNull.Value)
                    page.dateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                if (rdr["DateModified"] != DBNull.Value)
                    page.dateModified = Convert.ToDateTime(rdr["DateModified"]);
                if (rdr["DatePublished"] != DBNull.Value)
                    page.datePublished = Convert.ToDateTime(rdr["DatePublished"]);
                page.published = Convert.ToInt32(rdr["Published"]);
                page.authorId = Convert.ToInt32(rdr["Published"]);
                pages.Add(page);
            }
            con1.Close();
            return pages;
        }

        public void SavePage(string content)
        {
            //saving page meta data in db
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "INSERT INTO PAGES values('" + pageName + "','" + displayName + "',@dtc,@dtm," + published + ",@dtp," + authorId + ",@url,'user')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dtc", DateTime.Now);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            com1.Parameters.AddWithValue("@url", DBNull.Value);
            if (published == 1)
                com1.Parameters.AddWithValue("@dtp", DateTime.Now);
            else
                com1.Parameters.AddWithValue("@dtp", null);
            try
            {
                con1.Open();
                com1.ExecuteReader();
                con1.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UNIQUE"))//if page already exists with the same name
                    HttpContext.Current.Response.Write("Page " + pageName + " already exist");
                else
                    HttpContext.Current.Response.Write(ex.Message);
                goto exit;
            }

            //following are the strings containing fixed text as well as user text to be save on .aspx page and .cs page

            //tags  of .aspx page
            string header = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + pageName.Replace("'", "") +
                ".aspx.cs\" Inherits=\"ENaveed." + pageName.Replace("'", "") + "\" %>";
            string head = "<asp:Content ContentPlaceHolderID=\"head\" runat=\"server\">";
            string body = "<asp:Content ContentPlaceHolderID=\"body\" runat=\"server\">";
            string closingTag = "</asp:Content>";


            //heading of page
            string displayTitle="";
            if (displayName.Contains("''"))
            {

                displayName = displayName.Remove(displayName.IndexOf("''"),1);
            }
            displayTitle = "<h1>" + displayName + "</h1>";

            //complete .aspx page text
            string[] html = { header, head, displayTitle, closingTag, body, content, closingTag };
            
            //We can put option to select masterpage layout for each page naveed

            //text of .cs file
            string[] cs = { "using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Web;",
                "using System.Web.UI;", "using System.Web.UI.WebControls;","namespace ENaveed","{",
                "public partial class "+pageName.Replace("'", "")+": System.Web.UI.Page","{",
                "void Page_PreInit(Object sender, EventArgs e)","{","this.MasterPageFile = \"../MasterPages/Pages.Master\";","}",
            "protected void Page_Load(object sender, EventArgs e)","{","}","}","}" };

            // saving .aspx page in UserPages folder
            File.WriteAllLines(HttpContext.Current.Server.MapPath("../UserPages/" + pageName.Replace("'", "") + ".aspx"), html);

            //saving .cs file in the UserPages folder
            File.WriteAllLines(HttpContext.Current.Server.MapPath("../UserPages/" + pageName.Replace("'", "") + ".aspx.cs"), cs);
            
            //print result for user
            HttpContext.Current.Response.Write("page created");

            //redirect to newly created page
            HttpContext.Current.Response.Redirect("../UserPages/" + pageName.Replace("'", "") + ".aspx");
            exit:;//label for goto call when exception occurs
        }

        //edit page
        public void EditPage( List<string> content, int published,bool toggle)
        {
            string[] html = { content[0], content[1], content[2], content[3], content[4] };
            File.WriteAllLines(HttpContext.Current.Server.MapPath("../UserPages/" + pageName + ".aspx"), html);
            
            //saving page meta data in db
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1="";
            if (toggle && published==1)
                q1 = "UPDATE PAGES set displayName='" + content[1] + "', DateModified=@dtm, Published=1 ,DatePublished = @dtp";
            else
                q1 = "UPDATE PAGES set displayName='" + content[1] + "', DateModified=@dtm, published="+published+" where PageId="+pageId;
            
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            if (published == 1 && toggle)
                com1.Parameters.AddWithValue("@dtp", DateTime.Now);
            //else
              //  com1.Parameters.AddWithValue("@dtp", null);//check it
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

            HttpContext.Current.Response.Write("Page Updated");
            HttpContext.Current.Response.Write("<br/>Clicke<a href=\"../UserPages/" + pageName + ".aspx\">Here</a> to view");
        }

        public void SetPageID()
        {
            string q1 = "select Next value for Pages_seq";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            pageId = Convert.ToInt32(com1.ExecuteScalar());
            con1.Close();
        }

        //get page by id for editing
        public static Page_class GetPagebyID(string pageid)
        {
            Page_class page = new Page_class();
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select * from PAGES where PageID=" + pageid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                page.pageId = Convert.ToInt32(pageid);
                page.pageName = rdr["PageName"].ToString();
                page.displayName = rdr["DisplayName"].ToString();
                page.dateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                page.dateModified = Convert.ToDateTime(rdr["DateModified"]);
                page.datePublished = Convert.ToDateTime(rdr["DatePublished"]);
                page.published = Convert.ToInt32(rdr["Published"]);
                page.authorId = Convert.ToInt32(rdr["AuthorId"]);

            }
            con1.Close();
            return page;
        }
        public static List<string> GetTextofPage(string pageName)
        {
            string contents = "";
            string path = HttpContext.Current.Server.MapPath("~/UserPages/" + pageName.Replace("'","") + ".aspx");
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                    contents += sr.ReadLine();
            }
                /*using (FileStream fs = File.OpenRead(path))
                {
                    byte[] b = new byte[8];
                    //UTF8Encoding temp = new UTF8Encoding(true);

                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        //contents+=(temp.GetString(b)).ToString();
                        contents += b.ToString();
                    }
                    //contents.Replace("\r\n", " ");
                }*/
                int index1 = contents.IndexOf("<h");
            index1 += 4;
            string header = contents.Substring(0, index1);
            contents = contents.Substring(index1);
            index1 = contents.IndexOf("</h1");
            string title = contents.Substring(0, index1);
            contents = contents.Substring(index1);
            index1=contents.IndexOf("\">");
            index1 = index1 + 2;
            string mid_asp=contents.Substring(0,index1);
            contents = contents.Substring(index1);
            index1 = contents.IndexOf("</asp:Content>");
            string body = contents.Substring(0, index1);
            contents = contents.Substring(index1);
            string footer = contents;
            List<string> page_Complete = new List<string>();
            page_Complete.Add(header);
            page_Complete.Add(title);
            page_Complete.Add(mid_asp);
            page_Complete.Add(body);
            page_Complete.Add(footer);

            return page_Complete;
        }
    }
}
