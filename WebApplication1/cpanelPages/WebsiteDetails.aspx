<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebsiteDetails.aspx.cs" Inherits="WebApplication1.cpanelPages.WebsiteDetails" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content ContentPlaceHolderID="body" runat="server">
    
        <h1>Enter Website Details</h1>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Website Title" Width="200px"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tagline" Width="200px"></asp:Label>
        <asp:TextBox ID="txtTagline" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="Company" Width="200px"></asp:Label>
        <asp:TextBox ID="txtCompany" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label4" runat="server" Text="Company URL" Width="200px"></asp:Label>
        <asp:TextBox ID="txtUrl" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label5" runat="server" Text="Facebook" Width="200px"></asp:Label>
        <asp:TextBox ID="txtFb" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label6" runat="server" Text="Twitter" Width="200px"></asp:Label>
        <asp:TextBox ID="txtTwitter" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label8" runat="server" Text="Github" Width="200px"></asp:Label>
        <asp:TextBox ID="txtGithub" runat="server" Width="200px"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label7" runat="server" Text="About" Width="200px"></asp:Label>
        <br />
        <asp:TextBox ID="txtAbout" runat="server" Width="403px" Height="87px" TextMode="MultiLine"></asp:TextBox>
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" Width="409px" OnClick="Button1_Click" />
    
 
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    
 
</asp:Content>