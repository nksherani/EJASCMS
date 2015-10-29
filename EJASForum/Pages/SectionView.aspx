<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="SectionView.aspx.cs" Inherits="EJASForum.Pages.SectionView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <% Response.Write("<h1><a href=\"home.aspx\">"+forumtitle+"</h1>");
        Response.Write("<h2><a href=\"CategoryView.aspx?category="+category+"\">"+category+"</h2>");
        Response.Write("<h3><a href=\"SectionView.aspx?sectionid="+sectionid+"&thread=1&category="+category+"&section="+section+"\">"+section+"</a></h3>");
        foreach (var thr in NThreads)
        {
            Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+section+"&category="+category+"\">"+thr.ThreadTitle+"</a></h3>");
            Response.Write("<p>Dated: "+thr.DateModified+"</p>");
            thr.getAuthor();
            Response.Write("<p>Author: "+thr.Author+"</p>");

        }
        int next = thread + 30;
        int back = thread - 30;
        if(!(NThreads.Count<30))
            Response.Write("<h3><a id="+sec.SectionId+" class='sectionLink' href=\"SectionView.aspx?sectionid="+sec.SectionId+"&thread="+next+"&category="+category+"&section="+sec.SectionTitle+"\">"+"Next"+"</a></h3>");
        if(thread>1)
        Response.Write("<h3><a id="+sec.SectionId+" class='sectionLink' href=\"SectionView.aspx?sectionid="+sec.SectionId+"&thread="+back+"&category="+category+"&section="+sec.SectionTitle+"\">"+"Back"+"</a></h3>");
         %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyScript" runat="server">
</asp:Content>
