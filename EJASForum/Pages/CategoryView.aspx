<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="CategoryView.aspx.cs" Inherits="EJASForum.Pages.CategoryView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <%
        Response.Write("<h2><a href=\"CategoryView.aspx?category="+cat.CategoryTitle+"\">"+cat.CategoryTitle+"</a></h2>");

        foreach(var sec in cat.SectionList)
        {
            Response.Write("<h3><a id="+sec.SectionId+" class='sectionLink' href=\"SectionView.aspx?sectionid="+sec.SectionId+"&thread=1&category="+category+"&section="+sec.SectionTitle+"\">"+sec.SectionTitle+"</a></h3>");
            threads = sec.GetNThreads(thread, 20);
            foreach(var thr in threads)
            {
                Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+sec.SectionTitle+"&category="+category+"\">"+thr.ThreadTitle+"</a></h3>");
                Response.Write("<p>Dated:" + thr.DateModified + "</p>");
                thr.getAuthor();
                Response.Write("<p>Author: "+thr.Author+"</p>");

            }
        }

         %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyScript" runat="server">
</asp:Content>
