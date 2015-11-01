<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/forum.Master" CodeBehind="EditThread.aspx.cs" Inherits="EJASForum.Pages.EditThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/jquery-te-1.4.0.min.js"></script>
    <link href="../Styling/jquery-te-1.4.0.css" rel="stylesheet" />
    <link href="../Styling/Forum.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="editor-space">
    <h1>Create A New Thread:</h1>
    <asp:Label ID="Label4" runat="server" Text="Title" Width="200"></asp:Label>
    <asp:TextBox ID="txtTitle" runat="server" Width="545px"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select Category" Width="200px"></asp:Label>
    <asp:DropDownList ID="drpCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" Width="200px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Select Section" Width="200px"></asp:Label>
    <asp:DropDownList ID="drpSection" runat="server" Width="200px">
        <asp:ListItem>Select a section</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Publish" Width="200px"></asp:Label>
    <asp:DropDownList ID="drpPublish" runat="server" Width="200px" OnSelectedIndexChanged="drpPublish_SelectedIndexChanged">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtContent" CssClass="jqte-test" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Post" />
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyScript" runat="server">
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
