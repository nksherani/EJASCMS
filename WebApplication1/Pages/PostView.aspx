<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="PostView.aspx.cs" Inherits="WebApplication1.Pages.PostView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%
        string post="";
        Response.Write("<h3>Categories:</h3>");

        foreach (var i in v.categories)
        {
            Response.Write("<a href=\"CategoryViewPosts.aspx\">"+i.categoryName+"</a> ");
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

        //comments
        
        Response.Write("<div>");
        foreach (var comment in Ncomments)
        {
            Response.Write("<p><a href=\""+profile+".aspx\">"+comment.Commentor+"</a><span>"+comment.CommentBody+"</span></p>");
        }
        Response.Write("</div>");
         %>
    <asp:TextBox ID="TextBox1" Height="200px" Width="450px" runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Comment" OnClick="Button1_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navigation" runat="server">
</asp:Content>
