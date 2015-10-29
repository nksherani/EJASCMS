<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="WebApplication1.cpanelPages.EditComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Comment Editor</h1>
    <asp:Label ID="Label1" runat="server" Text="Post Title" Width="200px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label><asp:Label ID="lblPostTitle" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label><br/>
    <asp:Label ID="Label2" runat="server" Text="Comment" Width="200px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label><asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Font-Bold="True" ForeColor="#666666" Height="72px" Width="218px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Published" Width="200px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Commentor" Width="200px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label><asp:Label ID="lblCommentor" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Text="Date Time" Width="200px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label>
    <asp:Label ID="lblDateTime" runat="server" Text="Date Time" Width="500px" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" Width="422px" />
    <br />
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyscript" runat="server">
</asp:Content>
