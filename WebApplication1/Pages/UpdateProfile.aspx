<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="WebApplication1.Pages.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Update Profile</h1>

    </div>
        <asp:Label ID="Label2" runat="server" Text="First Name" Width="200px"></asp:Label>
        <asp:TextBox ID="txtFname" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name" Width="200px"></asp:Label>
        <asp:TextBox ID="txtLname" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Username" Width="200px"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Password" Width="200px"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Confirm Password" Width="200px"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email" Width="200px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="200px" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Date of Birth" Width="200px"></asp:Label>
        <asp:TextBox ID="txtDob" runat="server" Width="157px" Enabled="False" ReadOnly="True" TextMode="DateTime"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Select Date" Width="45px" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" SelectedDate="1992-07-07" Visible="False" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Sign Up" Width="400px" />
    </form>
</body>
</html>
