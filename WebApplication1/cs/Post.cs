using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1.cs
{
    public class Post
    {
        public int postId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public int published { get; set; }
        public DateTime? datePublished  { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public List<Category> categories = new List<Category>();
        public List<Tag> tags = new List<Tag>();
        
        public Post() { }
        //write constructor
        public Post(string title, string content,int published, List<string> lstCategories,string commaseparatedtaglist)
        {
            SetPostID();
            this.published = published;
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "INSERT INTO POSTS(PostId,PostTitle,PostContent,DateCreated,DateModified,Published,DatePublished,AuthorId)" +
                "values("+postId+",'" + title + "','" + content + "',@dtc,@dtm," + published + ",@dtp," + HttpContext.Current.Session["userid"] + ")";
            if (published == 0)
                q1 = "INSERT INTO POSTS(PostId,PostTitle,PostContent,DateCreated,DateModified,Published,AuthorId)" +
                "values(Next value for Posts_seq,'" + title + "','" + content + "',@dtc,@dtm," + published + "," + HttpContext.Current.Session["userid"] + ")";
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dtc", DateTime.Now);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            if (published == 1)
                com1.Parameters.AddWithValue("@dtp", DateTime.Now);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            Categories(this.postId, lstCategories);
            tag(this.postId, commaseparatedtaglist);
        }

        

        //read constructor
        public Post(int id,string _title, string _content,DateTime dtc, DateTime dtm ,int _published,DateTime dtp,int _authorId,string _author)
        {
            //SetPostID();
            postId = id;
            title = _title;
            content = _content;
            published = _published;
            dateCreated = dtc;
            dateModified = dtm;
            Author = _author;
            if (published == 1)
                datePublished = dtp;
            GetCategories(this);
            GetTags(this);
        }

        //postid
        public void SetPostID()
        {
            string q1 = "select Next value for Posts_seq";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            postId = Convert.ToInt32(com1.ExecuteScalar());
            con1.Close();
        }

        //update post
        public static void UpdatePost(int postid, string title, string content, int published,bool toggle, List<string> lstCategories, string commaseparatedtaglist)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "update POSTS set PostTitle='" + title + "', PostContent='" + content + 
                "', DateModified=@dtm,Published="+published+", DatePublished=@dtp where postid="+postid;
            if (published == 0)
                q1 = "update POSTS set PostTitle='" + title + "', PostContent='" + content +
                "', DateModified=@dtm,Published=" + published + " where postid=" + postid;

            if (published == 1 && !toggle)
                q1 = "update POSTS set PostTitle='" + title + "', PostContent='" + content +
                "', DateModified=@dtm where postid="+postid;
            SqlCommand com1 = new SqlCommand(q1, con1);
            //com1.Parameters.AddWithValue("@dtc", DateTime.Now);
            com1.Parameters.AddWithValue("@dtm", DateTime.Now);
            DateTime date=new DateTime();
            if (published == 1 && toggle)
                com1.Parameters.AddWithValue("@dtp", DateTime.Now);
            
                
            
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            Categories(postid ,lstCategories);
            tag(postid, commaseparatedtaglist);
        }

        //assign categories
        public static void Categories(int postid, List<string> lstCategories)
        {
            PostCategory.DeleteCatecoriesofPost(postid);

            foreach (string item in lstCategories)
            {
                
                    Category category = new Category();
                    category.GetCategoryId(item);
                    PostCategory postcategory = new PostCategory(postid, category);
                    postcategory.PostCategorySave();
                
            }


        }
        
        //assign tags
        public static void tag(int postid, string taglist)
        {
            if (!taglist.Equals(""))
            {
                List<string> TagIds = taglist.Split(',').ToList<string>();
                foreach (var v in TagIds)
                {
                    Tag tag = new Tag(v,postid);
                    //tags.Add(tag);
                    //save tags to db
                    tag.saveTagtoDb();
                }
            }
            
        }

        //getcategoriesofthispost
        public List<Category> GetCategories(Post post)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            List<Category> lstCategories = new List<Category>();
            string q1 = "select categoryId from postCategories where postID =" + post.postId;
            SqlCommand com1 = new SqlCommand(q1, con1);
            List<int> catIDs = new List<int>();
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                catIDs.Add(Convert.ToInt32(rdr[0]));
            }
            con1.Close();
            foreach(var v in catIDs)
            {
                q1 = "select * from categories where id=" + v;
                com1 = new SqlCommand(q1, con1);
                con1.Open();
                rdr = com1.ExecuteReader();
                while (rdr.Read())
                {
                    lstCategories.Add(new Category(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString()));
                }
                con1.Close();
                
            }
            categories = lstCategories;
            return lstCategories;
        }

        //gettagsofthispost
        public List<Tag> GetTags(Post post)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            List<Tag> lstTags = new List<Tag>();
            string q1 = "select tag from tags where pagepostID =" + post.postId;
            SqlCommand com1 = new SqlCommand(q1, con1);
            //List<int> catIDs = new List<int>();
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            while (rdr.Read())
            {
                lstTags.Add(new Tag(rdr["tag"].ToString(),post.postId));
            }
            con1.Close();
            tags = lstTags;
            return lstTags;
        }

        //load single post
        public static Post LoadPostbyId(int N)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            //N++;
            string q1 = "select * from Posts_View where published=1 and postID =" + N;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            Post post = new Post();
            while (rdr.Read())
            {
                string title = rdr["postTitle"].ToString();
                string content = rdr["postContent"].ToString();
                string Author = rdr["FirstName"].ToString();
                DateTime dtc = Convert.ToDateTime(rdr["dateCreated"]);
                DateTime dtm = Convert.ToDateTime(rdr["dateModified"]);
                DateTime dtp = Convert.ToDateTime(rdr["datePublished"]);
                int AuthorID = Convert.ToInt32(rdr["authorId"]);
                int postID = Convert.ToInt32(rdr["PostId"]);
                int published = 1;
                post = new Post(postID, title, content, dtc, dtm, published, dtp, AuthorID, Author);
                //NPosts.Add(post);
            }
            con1.Close();
            return post;
        }

        public static Post LoadPostbyIdAll(int N)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            //N++;
            string q1 = "select * from Posts_View where postID =" + N;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            Post post = new Post();
            while (rdr.Read())
            {
                string title = rdr["postTitle"].ToString();
                string content = rdr["postContent"].ToString();
                string Author = rdr["FirstName"].ToString();
                DateTime dtc = Convert.ToDateTime(rdr["dateCreated"]);
                DateTime dtm = Convert.ToDateTime(rdr["dateModified"]);
                DateTime dtp = Convert.ToDateTime(rdr["datePublished"]);
                int AuthorID = Convert.ToInt32(rdr["authorId"]);
                int postID = Convert.ToInt32(rdr["PostId"]);
                int published = Convert.ToInt32(rdr["Published"]); ;
                post = new Post(postID, title, content, dtc, dtm, published, dtp, AuthorID, Author);
                //NPosts.Add(post);
            }
            con1.Close();
            return post;
        }

        //search word is post content
        public static List<Post> SearchPostContentbyWord( string query)
        {
            Post post;
            List<Post> posts = new List<Post>();
            string q1 = "select * from Posts_View where postContent like '%" + query + "%'";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            SqlCommand com1 = new SqlCommand(q1, con1);
            SqlDataReader rdr;
            con1.Open();
            rdr = com1.ExecuteReader();

            while (rdr.Read())
            {
                string title = rdr["postTitle"].ToString();
                string content = rdr["postContent"].ToString();
                string Author = rdr["FirstName"].ToString();
                DateTime dtc = Convert.ToDateTime(rdr["dateCreated"]);
                DateTime dtm = Convert.ToDateTime(rdr["dateModified"]);
                DateTime dtp = Convert.ToDateTime(rdr["datePublished"]);
                int AuthorID = Convert.ToInt32(rdr["authorId"]);
                int postID = Convert.ToInt32(rdr["PostId"]);
                int published = Convert.ToInt32(rdr["Published"]); ;
                post = new Post(postID, title, content, dtc, dtm, published, dtp, AuthorID, Author);
                posts.Add(post);
            }
            con1.Close();
            return posts;
        }

        //load nposts of a category
        public static List<Post> GetNPostsbyCategory(int initial, int length,int catid)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select P.* from Posts_View P, PostCategories PC where P.PostId=PC.PostId and CategoryId="+catid;
            
            SqlDataReader rdr;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            rdr = com1.ExecuteReader();
            Post thread;
            List<Post> NThreads = new List<Post>();
            int n = 1;
            while (rdr.Read())
            {
                thread = new Post();
                thread.postId = Convert.ToInt32(rdr["postId"]);
                thread.title = rdr["postTitle"].ToString();
                thread.content = rdr["postContent"].ToString();
                thread.dateCreated = Convert.ToDateTime(rdr["dateCreated"]);
                thread.dateModified = Convert.ToDateTime(rdr["dateModified"]);
                thread.datePublished = Convert.ToDateTime(rdr["datePublished"]);
                thread.published = 1;
                thread.AuthorId = Convert.ToInt32(rdr["AuthorId"]);
                thread.Author = rdr["FirstName"].ToString();

                if (n >= initial && n <= initial + length - 1)//improve efficiency
                    NThreads.Add(thread);
                n++;
             }
            con1.Close();
            return NThreads;
        }

        //load nposts of a tag
        public static List<Post> GetNPostsbyTag(int initial, int length, string tag)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select P.* from Posts_View P, Tags T where P.PostId=T.PagePostId and tag='" + tag+"'";
            SqlDataReader rdr;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            rdr = com1.ExecuteReader();
            Post thread;
            List<Post> NThreads = new List<Post>();
            int n = 1;
            while (rdr.Read())
            {
                thread = new Post();
                thread.postId = Convert.ToInt32(rdr["postId"]);
                thread.title = rdr["postTitle"].ToString();
                thread.content = rdr["postContent"].ToString();
                thread.dateCreated = Convert.ToDateTime(rdr["dateCreated"]);
                thread.dateModified = Convert.ToDateTime(rdr["dateModified"]);
                thread.datePublished = Convert.ToDateTime(rdr["datePublished"]);
                thread.published = 1;
                thread.AuthorId = Convert.ToInt32(rdr["AuthorId"]);
                thread.Author = rdr["FirstName"].ToString();

                if (n >= initial && n <= initial + length - 1)//improve efficiency
                    NThreads.Add(thread);
                n++;
            }
            con1.Close();
            return NThreads;
        }



        //load posts
        public static List<Post> LoadFirstNPosts(int N)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            N++;
            string q1 = "select * from Posts_View where published=1 and postID <" + N;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            List<Post> NPosts = new List<Post>();
            while (rdr.Read())
            {
                string title = rdr["postTitle"].ToString();
                string content = rdr["postContent"].ToString();
                if (content.Length > 200)
                    content = content.Substring(0, 199) + "...." + "<br/><br/>Click Post Title to view more";
                string Author = rdr["FirstName"].ToString();
                DateTime dtc = Convert.ToDateTime(rdr["dateCreated"]);
                DateTime dtm = Convert.ToDateTime(rdr["dateModified"]);
                DateTime dtp = Convert.ToDateTime(rdr["datePublished"]);
                int AuthorID = Convert.ToInt32(rdr["authorId"]);
                int postID = Convert.ToInt32(rdr["PostId"]);
                int published = 1;
                Post post = new Post(postID,title, content, dtc, dtm, published, dtp, AuthorID,Author);
                NPosts.Add(post);
            }
            con1.Close();
            return NPosts;
        }

        
        public static List<Post> LoadNextNPosts(int i,int N)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            N = N + i;
            string q1 = "select * from Posts_View where published=1 and postID between "+i+" and " + N;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            SqlDataReader rdr = com1.ExecuteReader();
            List<Post> NPosts = new List<Post>();
            while (rdr.Read())
            {
                string title = rdr["postTitle"].ToString();
                string content = rdr["postContent"].ToString();
                DateTime dtc = Convert.ToDateTime(rdr["dateCreated"]);
                DateTime dtm = Convert.ToDateTime(rdr["dateModified"]);
                DateTime dtp = Convert.ToDateTime(rdr["datePublished"]);
                int AuthorID = Convert.ToInt32(rdr["authorId"]);
                int postID = Convert.ToInt32(rdr["PostId"]);
                string Author = rdr["FirstName"].ToString();
                int published = 1;
                Post post = new Post(postID, title, content, dtc, dtm, published, dtp, AuthorID,Author);
                NPosts.Add(post);
            }
            con1.Close();
            return NPosts;
        }

        public List<Comment> GetNComments(int initial, int length)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "SELECT * FROM Comment_Profile_view where published=1 and PostId = " + this.postId + " order by DateCreated";
            SqlDataReader rdr;
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            rdr = com1.ExecuteReader();
            Comment Reply;
            List<Comment> NReplies = new List<Comment>();
            int n = 1;
            while (rdr.Read())
            {
                Reply = new Comment();
                Reply.PostId = Convert.ToInt32(rdr["PostId"]);
                Reply.CommentId = Convert.ToInt32(rdr["CommentId"]);
                Reply.CommentBody = rdr["CommentBody"].ToString();
                Reply.Commentor = rdr["Commentor"].ToString();
                Reply.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
                Reply.DateModified = Convert.ToDateTime(rdr["DateModified"]);
                Reply.DatePublished = Convert.ToDateTime(rdr["DatePublished"]);
                Reply.Published = 1;
                Reply.CommentorId = Convert.ToInt32(rdr["CommentorId"]);
                if (n >= initial && n <= initial + length - 1)//improve efficiency
                    NReplies.Add(Reply);
                n++;
            }
            con1.Close();
            return NReplies;
        }

        public void PostComment(string comment)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "INSERT INTO Comment values(" + postId + ",'" + comment + "'," + HttpContext.Current.Session["userid"] + ",@dt,@dt,1,@dt)";
            SqlCommand com1 = new SqlCommand(q1, con1);
            com1.Parameters.AddWithValue("@dt", DateTime.Now);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }
    }
    
}
