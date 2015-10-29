<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="CategoryViewPosts.aspx.cs" Inherits="WebApplication1.Pages.CategoryViewPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%
        Response.Write("<h1>"+catname+"</h1>");
        string post;
        if (Nposts.Count < 10)
        {
            btnNext.Visible = false;
            btnBack.Visible = true;
        }
        if (Nposts.Count==0)
        {
            btnNext.Visible = false;
        }
        if (globaldata.pages_visited == 0)
            btnBack.Visible = false;
        else
            btnBack.Visible = true;
        foreach (var v in Nposts)
        {
            v.GetTags(v);
            v.GetCategories(v);
            Response.Write("<h3>Categories:</h3>");
            foreach(var i in v.categories)
            {
                Response.Write("<a href=\"CategoryViewPosts.aspx?catid="+i.categoryID+"&category="+i.categoryName+"\">"+i.categoryName+"</a> ");
            }

            Response.Write("<h3>Tags:</h3>");
            foreach(var i in v.tags)
            {
                Response.Write("<a href=\"TagViewPosts.aspx\">"+i.tag+"</a> ");
            }
            string profile = "ViewOthersProfile";
            if (v.AuthorId == Convert.ToInt32(Session["userid"]))
                profile = "MyProfile";
            post = "<div class=\"blog-post\"><h2 class=\"blog-post-title\"><a href=\"PostView.aspx?postid="+v.postId+"\">" + v.title + "</a></h2>" +
                "<p class=\"blog-post-meta\">" + v.dateCreated + "by <a href=\""+profile+".aspx\">" + v.Author + "</a></p>"+v.content+"</div>";
            Response.Write(post);

        }
         %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navigation" runat="server">
        <nav>
            <ul class="pager">
              <li><a href="#">
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></a></li>
                <li><a href="#">
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></a></li>
                
            </ul>
          </nav>
</asp:Content>
