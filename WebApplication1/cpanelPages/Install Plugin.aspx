<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install Plugin.aspx.cs" Inherits="WebApplication1.cpanelPages.Install_Plugin" MasterPageFile="~/MasterPages/Admin.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="body">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnInstallPlugin" runat="server" Text="Install Plugin" OnClick="btnInstallPlugin_Click" />
    
        <br />
        <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblResponse2" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Activate Plugin" Visible="False" />

</asp:Content>