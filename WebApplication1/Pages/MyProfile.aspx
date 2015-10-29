<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="WebApplication1.Pages.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>Update Profile</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
        <asp:Label ID="Label2" runat="server" Text="First Name" Width="200px"></asp:Label>
        <asp:TextBox ID="txtFName" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name" Width="200px"></asp:Label>
        <asp:TextBox ID="txtLName" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Username" Width="200px"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" Width="200px" OnTextChanged="txtUsername_TextChanged" AutoPostBack="True" ValidationGroup="password" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsername" ErrorMessage="Enter Username" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
        <asp:Label ID="lblUsernameAvailable" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Password" Width="200px"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px" ValidationGroup="password" ></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Confirm Password" Width="200px"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="200px" ValidationGroup="password"></asp:TextBox>
        <asp:Label ID="lblConfrm" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email" Width="200px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter an email address" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Facebook ID" Width="200px"></asp:Label>
        <asp:TextBox ID="txtFacebook" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Twitter" Width="200px"></asp:Label>
        <asp:TextBox ID="txtTwitter" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Date of Birth" Width="200px"></asp:Label>
        <asp:TextBox ID="txtDob" runat="server" Width="157px" Enabled="False" ReadOnly="True" TextMode="DateTime"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="BtnDate_Click" Text="Select Date" Width="45px" ValidationGroup="password" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" SelectedDate="1992-07-07" Visible="False" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged" ValidateRequestMode="Enabled">
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
        <asp:Button ID="BtnUpdate" runat="server" Text="Update" Width="400px" OnClick="BtnUpdate_Click" ValidationGroup="form" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navigation" runat="server">
</asp:Content>
