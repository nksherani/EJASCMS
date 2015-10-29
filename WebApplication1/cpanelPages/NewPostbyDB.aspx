<%@ Page validateRequest="false" Language="C#" AutoEventWireup="true"  CodeBehind="NewPostbyDB.aspx.cs" Inherits="WebApplication1.Pages.NewPagebyDB" MasterPageFile="~/MasterPages/Admin.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

    <link href="../css/jquery-te-1.4.0.css" rel="stylesheet" />
    <link href="../css/bootstrap-multiselect.css" rel="stylesheet" />
    <style>
        .labels{
            width:100px;
            padding:10px 50px 10px 10px;
        }
        .btnSubmit{
            background-color:brown;
            color:wheat;
            font-size:larger;
            padding:5px;
            width:200px;
        }
        
    </style>
    
</asp:Content>
        <asp:Content ContentPlaceHolderID="body" runat="server">
            <div style="margin:-20px;" class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
    <%
        if (posted)
        {
            Response.Write("Post has been published. Click <a href=\"../Pages/PostView.aspx?postid="+post.postId+"\"> Here </a> to View");
            posted = false;
        }
        %>
    <h1>Create a New Post</h1>
            <h4>Options</h4>
            <span class="labels">
                <asp:Label ID="Label1" runat="server" Text="Publish" Width="150px"></asp:Label></span>
            <asp:DropDownList ID="drpPublish" runat="server">
                <asp:ListItem Selected="True">Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <br />
            <span class="labels">
                <asp:Label ID="Label2" runat="server" Text="Categories" Width="150px"></asp:Label></span>

            <asp:ListBox ID="lstCategories" runat="server" SelectionMode="Multiple" Width="250px">
                
            </asp:ListBox>

            <br /><span class="labels">
            <asp:Label ID="Label3" runat="server" Text="Add New Category" Width="150px"></asp:Label></span>
            <asp:TextBox ID="txtNewCategory" runat="server" Width="200px"></asp:TextBox>
            <asp:DropDownList ID="drpParentCategory" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnNewCategory" runat="server" OnClick="btnNewCategory_Click" Text="Add" Width="100px" />
            <br />
            <span class="labels"><asp:Label ID="Label5" runat="server" Text="Add New Tags" Width="150px"></asp:Label></span>
            <asp:TextBox ID="txtNewTags" runat="server"></asp:TextBox>

            <br />
        <h3>Title</h3>
        <asp:TextBox ID="txtTitle" runat="server" Width="810px"></asp:TextBox>
        <br />
        <h3>Body</h3>
            <asp:TextBox ID="txtContent" CssClass="jqte-test" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
        
          <asp:Button ID="Button1" CssClass="btnSubmit" runat="server" OnClick="Button1_Click" Text="Submit Post" />
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
    <script type="text/javascript">
    $(function () {
        $('[id*=drpPublish]').multiselect({
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