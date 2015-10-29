<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllPlugins.aspx.cs" Inherits="WebApplication1.cpanelPages.AllPlugins" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Uninstall Selected Plugin" ValidationGroup="uninstall" Width="163px" />
        <asp:TextBox ID="txtIndex" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIndex" ErrorMessage="Select a plugin" ValidationGroup="uninstall"></asp:RequiredFieldValidator>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PluginId" DataSourceID="SqlDataSource1" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="PluginId" HeaderText="PluginId" InsertVisible="False" ReadOnly="True" SortExpression="PluginId" />
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activated" SortExpression="Activated">
                    <EditItemTemplate>
                        
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Activated(Convert.ToInt32(Eval("Activated"))) %>' OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Activated(Convert.ToInt32(Eval("Activated"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DateInstalled" HeaderText="DateInstalled" SortExpression="DateInstalled" />
                <asp:BoundField DataField="About" HeaderText="About" SortExpression="About" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:globaldb %>" DeleteCommand="DELETE FROM [Plugins] WHERE [PluginId] = @original_PluginId" InsertCommand="INSERT INTO [Plugins] ([Name], [Activated], [DateInstalled], [About], [Author]) VALUES (@Name, @Activated, @DateInstalled, @About, @Author)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Plugins]" UpdateCommand="UPDATE [Plugins] SET [Name] = @Name, [Activated] = @Activated, [DateInstalled] = @DateInstalled, [About] = @About, [Author] = @Author WHERE [PluginId] = @original_PluginId" OnSelecting="SqlDataSource1_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="original_PluginId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Activated" Type="Int32" />
                <asp:Parameter Name="DateInstalled" Type="DateTime" />
                <asp:Parameter Name="About" Type="String" />
                <asp:Parameter Name="Author" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Activated" Type="Int32" />
                <asp:Parameter Name="DateInstalled" Type="DateTime" />
                <asp:Parameter Name="About" Type="String" />
                <asp:Parameter Name="Author" Type="String" />
                <asp:Parameter Name="original_PluginId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

</asp:Content>