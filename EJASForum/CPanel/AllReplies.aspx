<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllReplies.aspx.cs" Inherits="EJASForum.CPanel.AllReplies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ReplyId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ReplyId" HeaderText="ReplyId" InsertVisible="False" ReadOnly="True" SortExpression="ReplyId" />
                <asp:BoundField DataField="ThreadId" HeaderText="ThreadId" SortExpression="ThreadId" />
                <asp:BoundField DataField="ReplyBody" HeaderText="ReplyBody" SortExpression="ReplyBody" />
                <asp:BoundField DataField="ReplierId" HeaderText="ReplierId" SortExpression="ReplierId" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [f_reply] WHERE [ReplyId] = @ReplyId" InsertCommand="INSERT INTO [f_reply] ([ThreadId], [ReplyBody], [ReplierId], [DateCreated], [DateModified], [Published], [DatePublished]) VALUES (@ThreadId, @ReplyBody, @ReplierId, @DateCreated, @DateModified, @Published, @DatePublished)" SelectCommand="SELECT * FROM [f_reply]" UpdateCommand="UPDATE [f_reply] SET [ThreadId] = @ThreadId, [ReplyBody] = @ReplyBody, [ReplierId] = @ReplierId, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [Published] = @Published, [DatePublished] = @DatePublished WHERE [ReplyId] = @ReplyId">
            <DeleteParameters>
                <asp:Parameter Name="ReplyId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ThreadId" Type="Int32" />
                <asp:Parameter Name="ReplyBody" Type="String" />
                <asp:Parameter Name="ReplierId" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ThreadId" Type="Int32" />
                <asp:Parameter Name="ReplyBody" Type="String" />
                <asp:Parameter Name="ReplierId" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="ReplyId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
