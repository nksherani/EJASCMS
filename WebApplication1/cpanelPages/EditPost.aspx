<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="WebApplication1.cpanelPages.EditPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery-te-1.4.0.css" rel="stylesheet" />
    <link href="../css/bootstrap-multiselect.css" rel="stylesheet" />
    
</asp:Content>
   <asp:Content ContentPlaceHolderID="body" runat="server">
        <div style="margin-left:-15px;" class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
    
    <h1>Create New Post</h1>
            <div><asp:Label ID="lblOptions" runat="server" Text="Options" Font-Bold="True" Font-Size="Large"></asp:Label></div>

            <asp:Label ID="Label1" runat="server" Text="Publish"></asp:Label>
            <asp:DropDownList ID="drpPublish" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPublish_SelectedIndexChanged">
                <asp:ListItem Selected="True">Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtToggle" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtToggleValue" runat="server" Visible="False">false</asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Categories"></asp:Label>

            <asp:ListBox ID="lstCategories" runat="server" SelectionMode="Multiple">
                
            </asp:ListBox>

            <br />
            <asp:Label ID="Label3" runat="server" Text="Add New Category"></asp:Label>
            <asp:TextBox ID="txtNewCategory" runat="server"></asp:TextBox>
            <asp:DropDownList ID="drpParentCategory" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnNewCategory" runat="server" OnClick="btnNewCategory_Click" Text="Add" />

            <br />

            <br />
            <asp:Label ID="Label5" runat="server" Text="Add New Tags"></asp:Label>
            <asp:TextBox ID="txtNewTags" runat="server"></asp:TextBox>

            <br />
        Title<br />
        <asp:TextBox ID="txtTitle" runat="server" Width="698px"></asp:TextBox>
        <br />
        Body
            <asp:TextBox ID="txtContent" CssClass="jqte-test" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Post" />
    </div>
        
    </asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="bodyscript">
    
    <script src="../js/bootstrap-multiselect.js"></script>

    <script type="text/javascript">
    $(function () {
        $('[id*=lstCategories]').multiselect({
            includeSelectAllOption: true
        });
    });
</script>
    
    <script type="text/javascript">
    $(function () {
        $('[id*=drpParentCategory]').multiselect({
            includeSelectAllOption: true
        });
    });
</script>



    <script src="../js/jquery-te-1.4.0.min.js"></script>
    
        <script>

        $('.jqte-test').jqte();

        // settings of status
        var jqteStatus = true;
        $(".status").click(function () {
            jqteStatus = jqteStatus ? false : true;
            $('.jqte-test').jqte({ "status": jqteStatus })
        });
    </script>



</asp:Content>