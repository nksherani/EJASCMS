<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllCategories.aspx.cs" Inherits="EJASForum.CPanel.ViewAllCategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CategoryId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" ReadOnly="True" SortExpression="CategoryId" />
                <asp:BoundField DataField="CategoryTitle" HeaderText="CategoryTitle" SortExpression="CategoryTitle" />
                <asp:BoundField DataField="SectionCount" HeaderText="SectionCount" SortExpression="SectionCount" />
                <asp:BoundField DataField="CreatorID" HeaderText="CreatorID" SortExpression="CreatorID" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="ForumId" HeaderText="ForumId" SortExpression="ForumId" />
                <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [f_category] WHERE [CategoryId] = @CategoryId" InsertCommand="INSERT INTO [f_category] ([CategoryId], [CategoryTitle], [SectionCount], [CreatorID], [DateCreated], [DateModified], [ForumId], [Published], [DatePublished]) VALUES (@CategoryId, @CategoryTitle, @SectionCount, @CreatorID, @DateCreated, @DateModified, @ForumId, @Published, @DatePublished)" SelectCommand="SELECT * FROM [f_category]" UpdateCommand="UPDATE [f_category] SET [CategoryTitle] = @CategoryTitle, [SectionCount] = @SectionCount, [CreatorID] = @CreatorID, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [ForumId] = @ForumId, [Published] = @Published, [DatePublished] = @DatePublished WHERE [CategoryId] = @CategoryId">
            <DeleteParameters>
                <asp:Parameter Name="CategoryId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CategoryId" Type="Int32" />
                <asp:Parameter Name="CategoryTitle" Type="String" />
                <asp:Parameter Name="SectionCount" Type="Int32" />
                <asp:Parameter Name="CreatorID" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="ForumId" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CategoryTitle" Type="String" />
                <asp:Parameter Name="SectionCount" Type="Int32" />
                <asp:Parameter Name="CreatorID" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="ForumId" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="CategoryId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
