<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="EJASForum.Pages.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyTop" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <% foreach (var v in EJASForum.CategoryList) {
            Response.Write("<div class=whole-category><div class=\"category\"><h2 ><a href=\"CategoryView.aspx?category="+v.CategoryTitle+"\">"+v.CategoryTitle+"</a></h2></div>");
            foreach(var sec in v.SectionList)
            {
                Response.Write("<div class=\"section\"><h3><a id="+sec.SectionId+" class='sectionLink' href=\"SectionView.aspx?sectionid="+sec.SectionId+"&thread=1&category="+v.CategoryTitle+"&section="+sec.SectionTitle+"\">"+sec.SectionTitle+"</a></h3></div>");
                Nthreads = sec.GetNThreads(1, 10);
                foreach(var thr in Nthreads)
                {

                    Response.Write("<div class=threadtitle><h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+sec.SectionTitle+"&category="+v.CategoryTitle+"\">"+thr.ThreadTitle+"</a></h3></div>");
                    thr.getAuthor();

                    Response.Write("<div class=thread-body>"+thr.ThreadBody+"</div>");
                    
                    Response.Write("<div class=meta-data><p>Dated:"+thr.DateModified+"</p>");
                    Response.Write("<p>Author: "+thr.Author+"</p></div>");

                }

            }Response.Write("</div>");
        } %>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="bodyScript">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    
</asp:Content>