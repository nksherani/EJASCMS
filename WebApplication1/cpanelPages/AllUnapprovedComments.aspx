<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUnapprovedComments.aspx.cs" MasterPageFile="~/MasterPages/Admin.Master" Inherits="WebApplication1.cpanelPages.AllUnapprovedComments" %>


<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:TextBox ID="txtSelected" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Edit Selected Comment" OnClick="Button1_Click" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Comment from the table" ControlToValidate="txtSelected"></asp:RequiredFieldValidator>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="CommentId" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" >
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:BoundField DataField="CommentId" HeaderText="Index" ReadOnly="True" SortExpression="CommentId" >
            <HeaderStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CommentBody" HeaderText="Comment" SortExpression="CommentBody" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Published" HeaderText="Published" SortExpression="Published" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PostTitle" HeaderText="Post" SortExpression="PostTitle" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:TextBox ID="txtCommentor" runat="server" Visible="False"></asp:TextBox><asp:TextBox ID="txtPostTitle" runat="server" Visible="False"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" SelectCommand="SELECT * FROM [comment_post_profiel_v] WHERE ([Published] = @Published)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="Published" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>