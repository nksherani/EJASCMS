<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="WebApplication1.NewPage" %>

<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v15.1, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Page</title>
    <link id="MyStyleSheet" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
        Title<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="698px"></asp:TextBox>
        <br />
        Body<dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server">
        </dx:ASPxHtmlEditor>
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
