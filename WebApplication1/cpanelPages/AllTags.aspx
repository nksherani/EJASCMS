<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTags.aspx.cs" Inherits="WebApplication1.cpanelPages.AllTags" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="PagePostId" HeaderText="PagePostId" SortExpression="PagePostId" />
                <asp:BoundField DataField="Tag" HeaderText="Tag" SortExpression="Tag" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [Tags] WHERE [Id] = @original_Id AND (([PagePostId] = @original_PagePostId) OR ([PagePostId] IS NULL AND @original_PagePostId IS NULL)) AND (([Tag] = @original_Tag) OR ([Tag] IS NULL AND @original_Tag IS NULL))" InsertCommand="INSERT INTO [Tags] ([PagePostId], [Tag]) VALUES (@PagePostId, @Tag)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Tags]" UpdateCommand="UPDATE [Tags] SET [PagePostId] = @PagePostId, [Tag] = @Tag WHERE [Id] = @original_Id AND (([PagePostId] = @original_PagePostId) OR ([PagePostId] IS NULL AND @original_PagePostId IS NULL)) AND (([Tag] = @original_Tag) OR ([Tag] IS NULL AND @original_Tag IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_PagePostId" Type="Int32" />
                <asp:Parameter Name="original_Tag" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PagePostId" Type="Int32" />
                <asp:Parameter Name="Tag" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PagePostId" Type="Int32" />
                <asp:Parameter Name="Tag" Type="String" />
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_PagePostId" Type="Int32" />
                <asp:Parameter Name="original_Tag" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
