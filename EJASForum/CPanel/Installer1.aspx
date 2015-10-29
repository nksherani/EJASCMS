<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Installer1.aspx.cs" Inherits="EJASForum.CPanel.Installer1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Forum Title" Width="200px"></asp:Label>
        <asp:TextBox ID="txtForumTitle" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description" Width="200px"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server" Height="206px" Width="399px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Width="403px" />
    
    </div>
    </form>
</body>
</html>
