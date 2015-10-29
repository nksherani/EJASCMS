<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="EJASForum.Pages.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyTop" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <% foreach (var v in EJASForum.CategoryList) {
            Response.Write("<h2><a href=\"CategoryView.aspx?category="+v.CategoryTitle+"\">"+v.CategoryTitle+"</a></h2>");
            foreach(var sec in v.SectionList)
            {
                Response.Write("<h3><a id="+sec.SectionId+" class='sectionLink' href=\"SectionView.aspx?sectionid="+sec.SectionId+"&thread=1&category="+v.CategoryTitle+"&section="+sec.SectionTitle+"\">"+sec.SectionTitle+"</a></h3>");
                Nthreads = sec.GetNThreads(1, 10);
                foreach(var thr in Nthreads)
                {

                    //Response.Write("<p><a href=\"ThreadView.aspx?ThreadId="+thr.ThreadID+"\">" + thr.ThreadTitle + "</a></p>");
                    Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+sec.SectionTitle+"&category="+v.CategoryTitle+"\">"+thr.ThreadTitle+"</a></h3>");
                    thr.getAuthor();

                    Response.Write("<p>Dated:"+thr.DateModified+"</p>");
                    Response.Write("<p>Author: "+thr.Author+"</p>");
                    
                }

            }
        } %>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="bodyScript">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    
</asp:Content>