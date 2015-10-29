<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/forum.Master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="EJASForum.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h1><a href="Registration.aspx">Registration</a></h1>
    <asp:Label ID="Label1" runat="server" Text="First Name" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtFName" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Last Name" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtLName" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Username" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtUsername" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Email" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtEmail" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Password" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Confirm Password" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtConfirmPassword" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Text="Facebook" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtFacebook" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Twitter" Height="20px" Width="200px"></asp:Label><asp:TextBox ID="txtTwitter" runat="server" Height="20px" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Date of Birth" Height="20px" Width="200px"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Select Date" OnClick="Button1_Click" />
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" SelectedDate="10/08/1990 15:24:00"></asp:Calendar>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyScript" runat="server">
</asp:Content>
