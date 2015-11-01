using EJASForum.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJASForum.Pages
{
    public partial class EditThread : System.Web.UI.Page
    {
        public static int togglecount = 0;
        public static string sec="";
        public static int threadid;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = 1; Session["forumid"] = 1;
            if (!(Convert.ToInt32(Session["userid"]) > 0))
                Response.Redirect("../Pages/Registration.aspx?error=1");
            if (IsPostBack)
                return;

            threadid = Convert.ToInt32(Request.QueryString["threadid"]);
            ForumThread thr = new ForumThread();
            thr.GetThread(threadid);
            List<string> categories = new List<string>();
            categories = ForumCategory.GetPublishedCategoryNames(Convert.ToInt32(Session["forumid"]));
            categories.Insert(0, "Select a category");
            drpCategory.DataSource = categories;
            drpCategory.DataBind();
            if (Request.QueryString["sec"] != null)
            {
                drpCategory.SelectedValue = Request.QueryString["cat"].ToString();
                if (drpCategory.SelectedIndex > 0)
                {
                    drpSection.DataSource = ForumSection.GetAllSectionNames(drpCategory.SelectedItem.Text);
                    drpSection.DataBind();
                    drpSection.SelectedValue=sec = Request.QueryString["sec"].ToString();

                }
                else
                {
                    drpSection.Items.Clear();
                    drpSection.Items.Add("Select a section");
                }
            }
            if (thr != null)
            {
                txtTitle.Text = thr.ThreadTitle;
                txtContent.Text = thr.ThreadBody;
                if (thr.Published == 1)
                    drpPublish.SelectedIndex = 0;
                else
                    drpPublish.SelectedIndex = 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int published = 0;
            if (drpPublish.SelectedIndex == 0)
                published = 1;
            bool toggle = false;
            //Session["userid"] = 1;
            ForumThread thread = new ForumThread();
            thread.Published = published;
            thread.ThreadBody = txtContent.Text;
            thread.ThreadTitle = txtTitle.Text;
            thread.DateModified = DateTime.Now;
            thread.ThreadID = threadid;
            if (!(togglecount % 2 == 0))
                toggle = true;
            else
                toggle = false;
                //thread.DatePublished = DateTime.Now;
            thread.SectionId = ForumSection.GetSectionIdbyName(sec);
            thread.UpdateThreadIntoDb(toggle);
            //thread.CreateThreadintoDb();
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCategory.SelectedIndex > 0)
            {
                drpSection.DataSource = ForumSection.GetAllSectionNames(drpCategory.SelectedItem.Text);
                drpSection.DataBind();
            }
            else
            {
                drpSection.Items.Clear();
                drpSection.Items.Add("Select a section");
            }

        }

        protected void drpPublish_SelectedIndexChanged(object sender, EventArgs e)
        {
            togglecount += 1;
        }
    }
}