<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllSections.aspx.cs" Inherits="EJASForum.CPanel.ViewAllSections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="SectionId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="SectionId" HeaderText="SectionId" ReadOnly="True" SortExpression="SectionId" />
                <asp:BoundField DataField="SectionTitle" HeaderText="SectionTitle" SortExpression="SectionTitle" />
                <asp:BoundField DataField="ThreadCount" HeaderText="ThreadCount" SortExpression="ThreadCount" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="CreatorId" HeaderText="CreatorId" SortExpression="CreatorId" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [f_section] WHERE [SectionId] = @SectionId" InsertCommand="INSERT INTO [f_section] ([SectionId], [SectionTitle], [ThreadCount], [DateCreated], [DateModified], [CreatorId], [CategoryID], [Published], [DatePublished]) VALUES (@SectionId, @SectionTitle, @ThreadCount, @DateCreated, @DateModified, @CreatorId, @CategoryID, @Published, @DatePublished)" SelectCommand="SELECT * FROM [f_section]" UpdateCommand="UPDATE [f_section] SET [SectionTitle] = @SectionTitle, [ThreadCount] = @ThreadCount, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [CreatorId] = @CreatorId, [CategoryID] = @CategoryID, [Published] = @Published, [DatePublished] = @DatePublished WHERE [SectionId] = @SectionId">
            <DeleteParameters>
                <asp:Parameter Name="SectionId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="SectionId" Type="Int32" />
                <asp:Parameter Name="SectionTitle" Type="String" />
                <asp:Parameter Name="ThreadCount" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="CreatorId" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="SectionTitle" Type="String" />
                <asp:Parameter Name="ThreadCount" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="CreatorId" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="SectionId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
