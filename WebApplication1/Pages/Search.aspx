<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication1.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Search Results for <%=query %></h1>
    <%
        foreach (var v in posts)
         {
             Response.Write("<h3>Categories:</h3>");
             foreach(var i in v.categories)
             {
                 Response.Write("<a href=\"CategoryViewPosts.aspx?catid="+i.categoryID+"&category="+i.categoryName+"\">"+i.categoryName+"</a> ");
             }

             Response.Write("<h3>Tags:</h3>");
             foreach(var i in v.tags)
             {
                 Response.Write("<a href=\"TagViewPosts.aspx?tag="+i.tag+"\">"+i.tag+"</a> ");
             }
             string profile = "ViewOthersProfile";
             if (v.AuthorId == Convert.ToInt32(Session["userid"]))
                 profile = "MyProfile";
             string post = "<div class=\"blog-post\"><h2 class=\"blog-post-title\"><a href=\"PostView.aspx?postid="+v.postId+"\">" + v.title + "</a></h2>" +
                 "<p class=\"blog-post-meta\">" + v.dateCreated + "by <a href=\""+profile+".aspx\">" + v.Author + "</a></p>"+v.content+"</div>";
             Response.Write(post);
             
         }
         %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navigation" runat="server">
</asp:Content>
