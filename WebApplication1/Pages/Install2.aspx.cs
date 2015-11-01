using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Pages
{
    public partial class Install2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btninstall_Click(object sender, EventArgs e)
        {
            string q1 = "insert into dbo.WebsiteDetails(WebsiteName,Tagline,Company,URL,DateCreated,DateModified)"+
                " values('" + txtwebsite.Text.Replace("'", "''") + "','" + txtTagline.Text.Replace("'", "''") + "','" +
                txtCompany.Text.Replace("'", "''") + "','" + txtURL.Text.Replace("'", "''") + "',@dtc,@dtm);";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dtc", DateTime.Now);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

            q1 = "insert into login values(next value for users_seq,'" + txtadminusername.Text.ToLower() + "','" + txtadminpassword.Text.ToString().GetHashCode().GetHashCode() + "');";
            q1+= "insert into profiles(id,role,email) values(cast((SELECT current_value FROM sys.sequences WHERE name = 'users_seq')as int),'admin','" + txtEmail.Text+"')";
            com1 = new SqlCommand(q1, con1);
            con1.Open();
            
            com1.ExecuteReader();
            con1.Close();

            Response.Redirect("home.aspx");
        }

        public void tables()
        {
            //creating tables by using ado.net and ddls
            string ddl_assemblies= "CREATE TABLE [dbo].[Assemblies] ([Id] INT IDENTITY (1, 1) NOT NULL,[AssemblyName] TEXT NULL, [PluginName]   TEXT NULL,PRIMARY KEY CLUSTERED ([Id] ASC) )";
            string ddl_categories = "CREATE TABLE [dbo].[categories] ([Id] INT  IDENTITY (1, 1) NOT NULL, [CategoryName] VARCHAR (50) NULL,[ParentName] VARCHAR (50) NULL, PRIMARY KEY CLUSTERED ([Id] ASC));";
            string ddl_comment = "CREATE TABLE [dbo].[Comment] ([CommentId] INT IDENTITY (1, 1) NOT NULL, [PostId] INT NOT NULL, [CommentBody]   VARCHAR(5000) NULL, [CommentorId] INT NULL, [DateCreated]   DATETIME NULL, [DateModified]  DATETIME NULL, [Published] INT NULL, [DatePublished] DATETIME NULL, PRIMARY KEY CLUSTERED([CommentId] ASC));";
            string ddl_login = "CREATE TABLE [dbo].[Login] ( [UserID] INT NOT NULL, [Username] VARCHAR (50) NULL, [Password] INT NULL, CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([UserID] ASC) ); ";
            string ddl_pages = "CREATE TABLE [dbo].[PAGES] ( [PageID] INT IDENTITY (1, 1) NOT NULL, [PageName] VARCHAR (50) NOT NULL, [DisplayName] VARCHAR (50) NOT NULL, [DateCreated] DATETIME NOT NULL, [DateModified] DATETIME NOT NULL, [Published] INT NOT NULL, [DatePublished] DATETIME NOT NULL, [AuthorID] INT NOT NULL, [PageURL] VARCHAR (50) NOT NULL, [PageType] VARCHAR (20) NOT NULL, CONSTRAINT [PK_PAGES_1] PRIMARY KEY CLUSTERED ([PageID] ASC), CONSTRAINT [UK_PAGES_PageName] UNIQUE NONCLUSTERED ([PageName] ASC) );";
            string ddl_plugins = "CREATE TABLE [dbo].[Plugins] ( [PluginId] INT IDENTITY (1, 1) NOT NULL, [Name] VARCHAR (50) NULL, [Activated] INT NULL, [DateInstalled] DATETIME NULL, [About] VARCHAR (500) NULL, [Author] VARCHAR (50) NULL, PRIMARY KEY CLUSTERED ([PluginId] ASC) );";
            string ddl_postcategories = "CREATE TABLE [dbo].[PostCategories] ( [Id] INT IDENTITY (1, 1) NOT NULL, [PostId] INT NOT NULL, [CategoryId] INT NOT NULL, CONSTRAINT [PK_PostCategories] PRIMARY KEY CLUSTERED ([CategoryId] ASC, [PostId] ASC) );";
            string ddl_posts = "CREATE TABLE [dbo].[Posts] ( [PostID] INT NOT NULL, [PostTitle] VARCHAR (50) NULL, [PostContent] TEXT NULL, [DateCreated] DATETIME NULL, [DateModified] DATETIME NULL, [Published] SMALLINT NULL, [DatePublished] DATETIME NULL, [AuthorId] INT NULL, CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([PostID] ASC) );";
            string ddl_profiles = "CREATE TABLE [dbo].[Profiles] ( [Id] INT NOT NULL, [FirstName] VARCHAR (50) NULL, [LastName] VARCHAR (50) NULL, [Role] VARCHAR (50) NULL, [DateOfBirth] DATETIME NULL, [Email] VARCHAR (50) NULL, [FacebookId] VARCHAR (150) NULL, [TwitterId] VARCHAR (50) NULL, PRIMARY KEY CLUSTERED ([Id] ASC) );";
            string ddl_tags = "CREATE TABLE [dbo].[Tags] ( [Id] INT IDENTITY (1, 1) NOT NULL, [PagePostId] INT NULL, [Tag] VARCHAR (50) NULL, PRIMARY KEY CLUSTERED ([Id] ASC) );";
            string ddl_websitedetails = "CREATE TABLE [dbo].[WebsiteDetails] ( [ID] INT IDENTITY (1, 1) NOT NULL, [WebsiteName] VARCHAR (50) NULL, [Tagline] VARCHAR (150) NULL, [DateCreated] DATETIME NULL, [DateModified] DATETIME NULL, [Company] VARCHAR (50) NULL, [URL] VARCHAR (50) NULL, [About] TEXT NULL, [FacebookPage] TEXT NULL, [TwitterTimeline] TEXT NULL, [Github] TEXT NULL, CONSTRAINT [PK_WebsiteDetails] PRIMARY KEY CLUSTERED ([ID] ASC) );";
            string ddl_comment_profile_view = "CREATE VIEW [dbo].[Comment_Profile_view] AS SELECT A.*, p.FirstName as Commentor FROM [Comment] A, [Profiles] p where A.CommentorId=p.Id";
            string ddl_login_v = "CREATE VIEW [dbo].[login_v] AS SELECT l.UserID, l.username, l.Password,p.role FROM login l, Profiles p where p.Id=l.UserID;";
            string ddl_posts_view = "CREATE VIEW [dbo].[Posts_View] AS SELECT P.*, pr.FirstName FROM [Posts] P, Profiles pr where P.AuthorId=pr.Id;";
            string ddl_comment_post_profile_v = "CREATE VIEW [dbo].[comment_post_profiel_v] AS SELECT comment.CommentId, Comment.CommentBody, Comment.DateModified, Comment.Published ,Posts.PostTitle,Profiles.FirstName FROM [Comment] Comment, Profiles Profiles, Posts Posts where Comment.PostId=Posts.PostID and Comment.CommentorId=Profiles.Id";

            //tables
            globaldata.create_table(ddl_assemblies, "Assemblies");
            globaldata.create_table(ddl_categories, "categories");
            globaldata.create_table(ddl_comment, "Comment");
            globaldata.create_table(ddl_login, "login");
            globaldata.create_table(ddl_pages, "Pages");
            globaldata.create_table(ddl_plugins, "Plugins");
            globaldata.create_table(ddl_postcategories, "PostCategories");
            globaldata.create_table(ddl_posts, "Posts");
            globaldata.create_table(ddl_profiles, "Profiles");
            globaldata.create_table(ddl_tags, "tags");
            globaldata.create_table(ddl_websitedetails, "WebsiteDetails");

            //views
            globaldata.create_table(ddl_comment_profile_view, "Comment_Profile_View");
            globaldata.create_table(ddl_login_v, "login_v");
            globaldata.create_table(ddl_posts_view, "Posts_view");
            globaldata.create_table(ddl_comment_post_profile_v, "comment_post_profile_v");
            
            //sequences
            globaldata.create_sequence("pages_seq");
            globaldata.create_sequence("users_seq");
            globaldata.create_sequence("posts_seq");
            
        }
    }
}