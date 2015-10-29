<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllThreads.aspx.cs" Inherits="EJASForum.CPanel.ViewAllThreads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:1000px; overflow:scroll;">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ThreadId" DataSourceID="SqlDataSource1" HorizontalAlign="Left" Width="500px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ThreadId" HeaderText="ThreadId" ReadOnly="True" SortExpression="ThreadId" />
                <asp:BoundField DataField="ThreadTitle" HeaderText="ThreadTitle" SortExpression="ThreadTitle" />
                <asp:BoundField DataField="ThreadBody" HeaderText="ThreadBody" SortExpression="ThreadBody" />
                <asp:BoundField DataField="SectionId" HeaderText="SectionId" SortExpression="SectionId" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="CreatorID" HeaderText="CreatorID" SortExpression="CreatorID" />
                <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [f_Thread] WHERE [ThreadId] = @ThreadId" InsertCommand="INSERT INTO [f_Thread] ([ThreadId], [ThreadTitle], [ThreadBody], [SectionId], [DateCreated], [DateModified], [CreatorID], [Published], [DatePublished]) VALUES (@ThreadId, @ThreadTitle, @ThreadBody, @SectionId, @DateCreated, @DateModified, @CreatorID, @Published, @DatePublished)" SelectCommand="SELECT * FROM [f_Thread]" UpdateCommand="UPDATE [f_Thread] SET [ThreadTitle] = @ThreadTitle, [ThreadBody] = @ThreadBody, [SectionId] = @SectionId, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [CreatorID] = @CreatorID, [Published] = @Published, [DatePublished] = @DatePublished WHERE [ThreadId] = @ThreadId">
            <DeleteParameters>
                <asp:Parameter Name="ThreadId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ThreadId" Type="Int32" />
                <asp:Parameter Name="ThreadTitle" Type="String" />
                <asp:Parameter Name="ThreadBody" Type="String" />
                <asp:Parameter Name="SectionId" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="CreatorID" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ThreadTitle" Type="String" />
                <asp:Parameter Name="ThreadBody" Type="String" />
                <asp:Parameter Name="SectionId" Type="Int32" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="CreatorID" Type="Int32" />
                <asp:Parameter Name="Published" Type="Int32" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="ThreadId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
