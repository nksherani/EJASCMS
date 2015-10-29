<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install2.aspx.cs" Inherits="WebApplication1.Pages.Install2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Installation - 2</title>
    <link href="../css/installer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="blog-masthead">STEP # 2</h1>
        <h2>MAKE AN ACCOUNT FOR ADMIN :)</h2>
        <asp:Label ID="Label1" runat="server" CssClass="names" Text="Website Name" Width="250px"></asp:Label>
        <asp:TextBox ID="txtwebsite" runat="server"  Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtwebsite" ErrorMessage="Enter Website Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label14" runat="server" CssClass="names" Text="Tagline" Width="250px"></asp:Label>
        <asp:TextBox ID="txtTagline" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTagline" ErrorMessage="Enter Tagline" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label12" runat="server" CssClass="names" Text="Company" Width="250px"></asp:Label>
        <asp:TextBox ID="txtCompany" runat="server" Width="250px"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" CssClass="names" Text="Company URL" Width="250px"></asp:Label>
        <asp:TextBox ID="txtURL" runat="server" Width="250px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="names" Text="Admin Username" Width="250px"></asp:Label>
        <asp:TextBox ID="txtadminusername" runat="server" Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtadminusername" ErrorMessage="Enter Username" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" CssClass="names" Text="Admin Password" Width="250px"></asp:Label>
        <asp:TextBox ID="txtadminpassword" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtadminpassword" ErrorMessage="Enter Password" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label8" runat="server" CssClass="names" Text="Confirm Password" Width="250px"></asp:Label>
        <asp:TextBox ID="txtadminconfirmpassword" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtadminconfirmpassword" ControlToValidate="txtadminpassword" ErrorMessage="Passwords must match" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
        <br />
        <asp:Label ID="Label15" runat="server" CssClass="names" Text="Email" Width="250px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email Address" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btninstall" runat="server" CssClass="button" style="margin-left: 0px" Text="LAUNCH EJAS" Width="255px" OnClick="btninstall_Click" />
    <%tables(); %>
    </form>
</body>
</html>
