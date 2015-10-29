<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllPages.aspx.cs" Inherits="WebApplication1.cpanelPages.AllPages" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
            Selected Index:<asp:TextBox ID="txtSelected" runat="server"></asp:TextBox>
            <br />
            Actions:<asp:DropDownList ID="drpActions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpActions_SelectedIndexChanged">
                <asp:ListItem Value="Edit in Full Editor">Edit in Full Editor</asp:ListItem>
                    </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Open Selected Page in Editor" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PageID" DataSourceID="SqlDataSource1" OnRowDeleted="GridView1_RowDeleted1" OnRowDeleting="GridView1_RowDeleting1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="PageID" HeaderText="PageID" ReadOnly="True" SortExpression="PageID" InsertVisible="False" />
                <asp:BoundField DataField="PageName" HeaderText="PageName" SortExpression="PageName" />
                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
                <asp:BoundField DataField="AuthorID" HeaderText="AuthorID" SortExpression="AuthorID" />
                <asp:BoundField DataField="PageURL" HeaderText="PageURL" SortExpression="PageURL" />
                <asp:BoundField DataField="PageType" HeaderText="PageType" SortExpression="PageType" />
            </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [PAGES] WHERE [PageID] = @original_PageID" InsertCommand="INSERT INTO [PAGES] ([PageName], [DisplayName], [DateCreated], [DateModified], [Published], [DatePublished], [AuthorID], [PageURL], [PageType]) VALUES (@PageName, @DisplayName, @DateCreated, @DateModified, @Published, @DatePublished, @AuthorID, @PageURL, @PageType)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [PAGES] WHERE ([PageType] = @PageType)" UpdateCommand="UPDATE [PAGES] SET [PageName] = @PageName, [DisplayName] = @DisplayName, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [Published] = @Published, [DatePublished] = @DatePublished, [AuthorID] = @AuthorID, [PageURL] = @PageURL, [PageType] = @PageType WHERE [PageID] = @original_PageID" OnSelecting="SqlDataSource1_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="original_PageID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PageName" Type="String" />
                <asp:Parameter Name="DisplayName" Type="String" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="Published" Type="Int16" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="AuthorID" Type="Int32" />
                <asp:Parameter Name="PageURL" Type="String" />
                <asp:Parameter Name="PageType" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="user" Name="PageType" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="PageName" Type="String" />
                <asp:Parameter Name="DisplayName" Type="String" />
                <asp:Parameter Name="DateCreated" Type="DateTime" />
                <asp:Parameter Name="DateModified" Type="DateTime" />
                <asp:Parameter Name="Published" Type="Int16" />
                <asp:Parameter Name="DatePublished" Type="DateTime" />
                <asp:Parameter Name="AuthorID" Type="Int32" />
                <asp:Parameter Name="PageURL" Type="String" />
                <asp:Parameter Name="PageType" Type="String" />
                <asp:Parameter Name="original_PageID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

</asp:Content>