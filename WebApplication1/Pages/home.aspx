<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.Pages.home" MasterPageFile="~/MasterPages/Pages.Master" %>




<asp:Content ContentPlaceHolderID="body" runat="server">

     <br />
    
     <%  string post;
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
             post = "<div class=\"blog-post\"><h2 class=\"blog-post-title\"><a href=\"PostView.aspx?postid="+v.postId+"\">" + v.title + "</a></h2>" +
                 "<p class=\"blog-post-meta\">" + v.dateCreated + "by <a href=\""+profile+".aspx\">" + v.Author + "</a></p>"+v.content+"</div>";
             Response.Write(post);
             
         }
        %>


</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="navigation">

    <nav>
            <ul class="pager">
              <li><a href="#">
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></a></li>
                <li><a href="#">
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></a></li>
                
            </ul>
          </nav>

</asp:Content>