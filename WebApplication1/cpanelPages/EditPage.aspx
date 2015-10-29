<%@ Page validateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="WebApplication1.cpanelPages.EditPage" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
        <script src="../js/jquery-1.11.1.min.js"></script>
    <link href="../css/jquery-te-1.4.0.css" rel="stylesheet" />
    <link href="../css/bootstrap-multiselect.css" rel="stylesheet" />

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
        <h1>Create New Page</h1>
            <div><asp:Label ID="lblOptions" runat="server" Text="Options" Font-Bold="True" Font-Size="Large"></asp:Label></div>

            <asp:Label ID="Label1" runat="server" Text="Publish"></asp:Label>
            <asp:DropDownList ID="drpPublish" runat="server" OnSelectedIndexChanged="drpPublish_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True">Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtSelectedIndex" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtToggle" runat="server" Visible="False">false</asp:TextBox>
            <br />

            <br />

            <br />
        Title<br />
        <asp:TextBox ID="txtTitle" runat="server" Width="698px"></asp:TextBox>
        <br />
        Body
            <asp:TextBox ID="txtContent" CssClass="jqte-test" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Post" />
            <br />

</asp:Content>

    <asp:Content ContentPlaceHolderID="bodyscript" runat="server">
        <script src="../js/jquery-te-1.4.0.min.js"></script>
    
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