using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace EJASForum.classes
{
    public static class Installer
    {
        //create tables
        public static void CreateTables()
        {
            string ddl_f_category = "CREATE TABLE [dbo].[f_category] ( [CategoryId] INT IDENTITY (1, 1) NOT NULL, [CategoryTitle] VARCHAR (100) NULL, [SectionCount] INT NULL, [CreatorID] INT NULL, [DateCreated] DATETIME NULL, [DateModified] DATETIME NULL, [ForumId] INT NULL, [Published] INT NULL, [DatePublished] DATETIME NULL, [Description] TEXT NULL, PRIMARY KEY CLUSTERED ([CategoryId] ASC) );";
            create_table(ddl_f_category, "f_category");

            string ddl_f_forumdetails = "CREATE TABLE [dbo].[f_forumdetails] ([ForumId] INT NOT NULL IDENTITY, [ForumTitle] VARCHAR(100) NULL,    [CategoryCount]" +
        "INT NULL, [DateCreated]   DATETIME NULL, [CreatorID]     INT NULL, [Published] INT NULL," + " [About] VARCHAR(500) NULL, "
        + " PRIMARY KEY CLUSTERED([ForumId] ASC));";
            create_table(ddl_f_forumdetails, "f_forumdetails");

            string ddl_f_reply = "CREATE TABLE [dbo].[f_reply] ([ReplyId]       INT IDENTITY (1, 1) NOT NULL," +
    "[ThreadId]      INT NOT NULL, [ReplyBody]     VARCHAR(5000) NULL, [ReplierId] INT NULL, [DateCreated]   DATETIME NULL," +
    "[DateModified]  DATETIME NULL, [Published]     INT NULL, [DatePublished] DATETIME NULL, PRIMARY KEY CLUSTERED([ReplyId] ASC));";
            create_table(ddl_f_reply, "f_reply");

            string ddl_f_section = "CREATE TABLE [dbo].[f_section] ( [SectionId] INT IDENTITY (1, 1) NOT NULL, [SectionTitle] VARCHAR (100) NULL, [ThreadCount] INT NULL, [DateCreated] DATETIME NULL, [DateModified] DATETIME NULL, [CreatorId] INT NULL, [CategoryID] INT NULL, [Published] INT NULL, [DatePublished] DATETIME NULL, [Description] TEXT NULL, PRIMARY KEY CLUSTERED ([SectionId] ASC) );";
            create_table(ddl_f_section, "f_section");

            string ddl_f_Thread = "CREATE TABLE [dbo].[f_Thread] ( [ThreadId] INT IDENTITY (1, 1) NOT NULL, [ThreadTitle] VARCHAR (100) NULL, [ThreadBody] VARCHAR (5000) NULL, [SectionId] INT NULL, [DateCreated] DATETIME NULL, [DateModified] DATETIME NULL, [CreatorID] INT NULL, [Published] INT NULL, [DatePublished] DATETIME NULL, PRIMARY KEY CLUSTERED ([ThreadId] ASC) );";
            create_table(ddl_f_Thread, "f_Thread");

        }

        //create tables using ddl
        public static void create_table(string ddl, string table_name)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(ddl, con1);
            string exception_query = "";
            try//normal execution if table is not already present in database
            {
                con1.Open();
                com1.ExecuteReader();
                con1.Close();
                HttpContext.Current.Response.Write("<p style=\"color:green\">Table " + table_name + " Created Successfully</p>");
            }
            catch (SqlException ex)//if table is present or some other reason prevents the function to work properly
                                   //then catch block is run to display the error details
            {
                HttpContext.Current.Response.Write("<p style =\"color:red\">" + ex.Message + "</p>");

                //empty the already existing table
                exception_query = "truncate table [dbo].[" + table_name + "]";
                com1 = new SqlCommand(exception_query, con1);
                try
                {
                    //execute truncation
                    //com1.ExecuteReader();
                    con1.Close();
                }
                catch (SqlException exc)//truncation failed
                {
                    //print erroor message
                    HttpContext.Current.Response.Write("<p style =\"color:red\">" + exc.Message + "</p>");
                    con1.Close();
                }

            }
        }

        //Create Forum Details/About
        public static void ForumDetailsStarting(string title, string about)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "INSERT INTO f_forumdetails values('" + title + "',0,@dt,@creatorid,1,'" + about + "')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dt", DateTime.Now);
            com1.Parameters.AddWithValue("@creatorid", 0);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            q1 = "INSERT INTO PAGES(PageName,DisplayName,DateCreated,DateModified,Published,DatePublished,AuthorID,PageURL,PageType)" +
                " VALUES('home.aspx','" + title + "',@dtc,@dtm,1,@dtp,@creatorid,'../Plugins/EJASForum_zip/Pages/home.aspx','plugin')";
            com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dtc", DateTime.Now);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            com1.Parameters.AddWithValue("@dtp", DateTime.Now);
            com1.Parameters.AddWithValue("@creatorid", 1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

        }

        //uninstallation methods 
        //delete folders of plugin
        public static void DeleteDirectory(string path)
        {
            HttpContext.Current.Server.MapPath(path);
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                //Delete a Directory
                Directory.Delete(path);
            }
            HttpContext.Current.Response.Redirect(HttpContext.Current.Server.MapPath("/"));
        }

        //dropping tables for uninstalling
        public static void DropTables(string pagepath, string folder)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "drop table f_category; drop table f_forumdetails; drop table f_reply; drop table f_section; drop table f_Thread;";

            SqlCommand com1 = new SqlCommand(q1, con1);
            try
            {
                con1.Open();
                com1.ExecuteReader();
                con1.Close();
                HttpContext.Current.Response.Write("Tables deleted");
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                con1.Close();
            }


            q1 = "delete from pages where PageURL='" + pagepath + "'";
            com1 = new SqlCommand(q1, con1);
            try
            {
                con1.Open();
                com1.ExecuteReader();
                con1.Close();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                con1.Close();
            }
        }
    }
}