<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="AllPosts.aspx.cs" Inherits="WebApplication1.cpanelPages.AllPosts1" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body"><div>
            Selected Index:<asp:TextBox ID="txtSelected" runat="server"></asp:TextBox>
            <br />
            Actions:<asp:DropDownList ID="drpActions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpActions_SelectedIndexChanged">
                <asp:ListItem Value="Edit in Full Editor">Edit in Full Editor</asp:ListItem>
                    </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PostID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="PostID" HeaderText="PostID" ReadOnly="True" SortExpression="PostID" />
                    <asp:BoundField DataField="PostTitle" HeaderText="PostTitle" SortExpression="PostTitle" />
                    <asp:BoundField DataField="PostContent" HeaderText="PostContent" SortExpression="PostContent" />
                    <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
                    <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" />
                    <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" />
                    <asp:BoundField DataField="DatePublished" HeaderText="DatePublished" SortExpression="DatePublished" />
                    <asp:BoundField DataField="AuthorId" HeaderText="AuthorId" SortExpression="AuthorId" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [Posts] WHERE [PostID] = @original_PostID" InsertCommand="INSERT INTO [Posts] ([PostID], [PostTitle], [PostContent], [DateCreated], [DateModified], [Published], [DatePublished], [AuthorId]) VALUES (@PostID, @PostTitle, @PostContent, @DateCreated, @DateModified, @Published, @DatePublished, @AuthorId)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Posts]" UpdateCommand="UPDATE [Posts] SET [PostTitle] = @PostTitle, [PostContent] = @PostContent, [DateCreated] = @DateCreated, [DateModified] = @DateModified, [Published] = @Published, [DatePublished] = @DatePublished, [AuthorId] = @AuthorId WHERE [PostID] = @original_PostID">
                <DeleteParameters>
                    <asp:Parameter Name="original_PostID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PostID" Type="Int32" />
                    <asp:Parameter Name="PostTitle" Type="String" />
                    <asp:Parameter Name="PostContent" Type="String" />
                    <asp:Parameter Name="DateCreated" Type="DateTime" />
                    <asp:Parameter Name="DateModified" Type="DateTime" />
                    <asp:Parameter Name="Published" Type="Int16" />
                    <asp:Parameter Name="DatePublished" Type="DateTime" />
                    <asp:Parameter Name="AuthorId" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="PostTitle" Type="String" />
                    <asp:Parameter Name="PostContent" Type="String" />
                    <asp:Parameter Name="DateCreated" Type="DateTime" />
                    <asp:Parameter Name="DateModified" Type="DateTime" />
                    <asp:Parameter Name="Published" Type="Int16" />
                    <asp:Parameter Name="DatePublished" Type="DateTime" />
                    <asp:Parameter Name="AuthorId" Type="Int32" />
                    <asp:Parameter Name="original_PostID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div></asp:Content>
        
