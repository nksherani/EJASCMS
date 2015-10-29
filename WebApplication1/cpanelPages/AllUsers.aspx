<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="WebApplication1.cpanelPages.AllUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>All Users</h1>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:TemplateField HeaderText="Role" SortExpression="Role">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Role") %>'>
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Registered User</asp:ListItem>
                        <asp:ListItem>Moderator</asp:ListItem>
                        <asp:ListItem>Editor</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="FacebookId" HeaderText="FacebookId" SortExpression="FacebookId" />
            <asp:BoundField DataField="TwitterId" HeaderText="TwitterId" SortExpression="TwitterId" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [Profiles] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Profiles] ([Id], [FirstName], [LastName], [Role], [DateOfBirth], [Email], [FacebookId], [TwitterId]) VALUES (@Id, @FirstName, @LastName, @Role, @DateOfBirth, @Email, @FacebookId, @TwitterId)" SelectCommand="SELECT * FROM [Profiles]" UpdateCommand="UPDATE [Profiles] SET [FirstName] = @FirstName, [LastName] = @LastName, [Role] = @Role, [DateOfBirth] = @DateOfBirth, [Email] = @Email, [FacebookId] = @FacebookId, [TwitterId] = @TwitterId WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Role" Type="String" />
            <asp:Parameter Name="DateOfBirth" Type="DateTime" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="FacebookId" Type="String" />
            <asp:Parameter Name="TwitterId" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Role" Type="String" />
            <asp:Parameter Name="DateOfBirth" Type="DateTime" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="FacebookId" Type="String" />
            <asp:Parameter Name="TwitterId" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyscript" runat="server">
</asp:Content>
