<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/cpanel.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="EJASForum.CPanel.CreateCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Category Title" Width="200px"></asp:Label><asp:TextBox ID="txtTitle1" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Publish" Width="200px"></asp:Label><asp:DropDownList ID="drpPublish1" runat="server" Width="200px">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>

    <br />
    <asp:Label ID="Label3" runat="server" Text="Description" Width="200px"></asp:Label>
    <br />
    <asp:TextBox ID="txtDesc1" runat="server" Height="104px" TextMode="MultiLine" Width="400px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Category" Width="400px" />

</asp:Content>
