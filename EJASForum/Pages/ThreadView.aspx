<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="ThreadView.aspx.cs" Inherits="EJASForum.Pages.ThreadView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styling/Forum.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <% Response.Write("<div class=whole-category><div class=\"category\"><h2><a href=\"CategoryView.aspx?category="+category+"\">"+category+"</a></h2></div>");
        Response.Write("<div class=\"section\"><h3><a href=\"SectionView.aspx?sectionid="+thr.SectionId+"&category="+category+"&section="+section+"\">"+section+"</a></h3></div>");
        Response.Write("<div class=threadtitle><h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply=1&section="+section+"&category="+category+"\">"+thr.ThreadTitle+"</a></h3></div>");
        Response.Write("<div class=meta-data><p>Dated:"+thr.DateModified+"</p>");
        Response.Write("<p>Author: "+thr.Author+"</p></div>");

        if (Convert.ToBoolean(Session["admin"]))
            Response.Write("<div class=toolbar><a href=\"../CPanel/EditThread.aspx?threadid="+thr.ThreadID+"&sec="+section.Replace(" ","+")+"&cat="+category+"\">Edit Thread</a></div>");
        else if(Convert.ToInt32(Session["userid"])==thr.CreatorId)
            Response.Write("<div class=toolbar><a href=\"../Pages/EditThread.aspx?threadid="+thr.ThreadID+"&sec="+section.Replace(" ","+")+"&cat="+category+"\">Edit Thread</a></div>");
        Response.Write("<div class=thread-body><p>"+thr.ThreadBody+"</p></div></div>");
         %>
    <div>
        <%//display replies
            foreach(var r in NReplies)
            {
                if (r.ReplierId == Convert.ToInt32(Session["userid"]))
                    Response.Write("<div class=whole-comment><a href=\"MyProfile.aspx?userid=" + r.ReplierId + "\">"+r.Replier+"</a>");
                else
                    Response.Write("<a href=\"OthersProfiles.aspx?userid=" + r.ReplierId + "\">"+r.Replier+"</a><br/ >");
                Response.Write(r.DateModified);
                Response.Write("<p>" + r.ReplyBody + "</p></div>");
            }
            int next = Convert.ToInt32(reply)+10;
            int back = Convert.ToInt32(reply)-10;
            if(!(NReplies.Count<10))
            {
                Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply="+next+"&section="+section+"&category="+category+"\">"+"Next"+"</a></h3>");
                if(reply_pages>1)//naveed fix back button
                    Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply="+back+"&section="+section+"&category="+category+"\">"+"Back"+"</a></h3>");
            }
            else
            {
                if(reply_pages>1)
                Response.Write("<h3><a href=\"ThreadView.aspx?threadid="+thr.ThreadID+"&reply="+back+"&section="+section+"&category="+category+"\">"+"Back"+"</a></h3>");
                
            }
             %>
    </div>
    <div>
        <%
            //post a reply
             %>
        <asp:TextBox ID="txtContent" CssClass="jqte-test" runat="server" ValidateRequestMode="Disabled" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </div>
    <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyScript" runat="server">
    <script src="../Scripts/jquery-te-1.4.0.min.js"></script>
        <script>

        $('.jqte-test').jqte();

        // settings of status
        var jqteStatus = true;
        $(".status").click(function () {
            jqteStatus = jqteStatus ? false : true;
            $('.jqte-test').jqte({ "status": jqteStatus })
        });
    </script>

</asp:Content>
