<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install1.aspx.cs" Inherits="WebApplication1.Pages.Install"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Installation - 1</title>
    <link href="../css/installer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="blog-masthead">STEP # 1</h1>
        
        <h2>ENTER DATABASE CREDENTIALS</h2>
        <br />
        <asp:Label ID="Label1" CssClass="names" runat="server" Text="Database Name" Width="250px"></asp:Label>
        <asp:TextBox ID="txtdbname" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdbname" ErrorMessage="Enter Database Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" CssClass="names" Text="Server" Width="250px"></asp:Label>
        <asp:TextBox ID="txtservername" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtservername" ErrorMessage="Enter Server Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label6" CssClass="names" runat="server" Text="Database Username" Width="250px"></asp:Label>
        <asp:TextBox ID="txtdbusername" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdbusername" ErrorMessage="Enter Username" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label7" runat="server" CssClass="names" Text="Database Password" Width="250px"></asp:Label>
        <asp:TextBox ID="txtdbpassword" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdbpassword" ErrorMessage="Enter Database Password" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label9" runat="server" CssClass="names" Text="Confirm Password" Width="250px"></asp:Label>
        <asp:TextBox ID="txtdbconfirmpassword" runat="server" Width="250px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtdbconfirmpassword" ControlToValidate="txtdbpassword" ErrorMessage="Passwords must match" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btninstall" runat="server" CssClass="button" style="        margin-left: 0px" Text="NEXT" Width="258px" OnClick="btninstall_Click" />
    </form>
</body>
</html>
