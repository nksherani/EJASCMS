<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="WebApplication1.cpanelPages.NewPage" %>


<asp:Content ContentPlaceHolderID="head" runat="server">

    <link href="../css/jquery-te-1.4.0.css" rel="stylesheet" />
    <link href="../css/bootstrap-multiselect.css" rel="stylesheet" />
    
</asp:Content>
    <asp:Content ContentPlaceHolderID="body" runat="server">
        <div style="margin-left:-15px;" class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
    
    <h1>Create New Page</h1>
            <div><asp:Label ID="lblOptions" runat="server" Text="Options" Font-Bold="True" Font-Size="Large"></asp:Label></div>

            <asp:Label ID="Label1" runat="server" Text="Publish"></asp:Label>
            <asp:DropDownList ID="drpPublish" runat="server">
                <asp:ListItem Selected="True">Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <br />

            <br />

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
    
    <%--<script src="../js/bootstrap-multiselect.js"></script>

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
</script>--%>



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