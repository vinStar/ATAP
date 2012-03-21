<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATAP</title>
    <link href="Styles/Table.css" rel="stylesheet" type="text/css" />
    <link href="Styles/custom-theme/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="Styles/custom-theme/jquery.ui.1.8.16.ie.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />

     <style>
      body {
        padding-top: 60px; /* 60px to make the container go all the way to the bottom of the topbar */
      }
    </style>

    <link href="Styles/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/docs.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    

</head>
<body>
    <form id="form1" runat="server">


    <div class="navbar navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container">
      
          <a class="brand" href="#">ATAP Project</a>
         
          
        </div>
      </div>
    </div>

    <div class="container">

    <div class="subnav subnav-fixed">
     <ul class="nav nav-pills">
              <li class="active"><a href="Default.aspx">Appeals Lookup</a></li>

            </ul>
    </div>

      

        <asp:GridView ID="gvDocsToPDF" UseAccessibleHeader="true" CellPadding="5" CellSpacing="0" Width="100%"
           CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
            
             runat="server">
             <Columns>
             <asp:TemplateField>
             <ItemTemplate>
             
                 <asp:CheckBox ID="cbSelect" AutoPostBack="true" OnCheckedChanged="cbSelect_CheckedChanged" Checked="true" runat="server">
                 </asp:CheckBox>
             </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Volume" />
             <asp:TemplateField HeaderText="Section" />
             <asp:BoundField DataField="_sFileName" HeaderText="File Name" />
             <asp:BoundField DataField="_sFileURL" HeaderText="File URL" />
             <asp:BoundField DataField="_iJobOrder" HeaderText="Order" />
             <asp:BoundField DataField="_iPages" HeaderText="Pages" />

             </Columns>
        </asp:GridView>
        <asp:Literal ID="ltTotalPgs" runat="server"></asp:Literal><br />

        <asp:Literal ID="ltLocalDir" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltFolderDir" runat="server"></asp:Literal><br />

        <br />

      
        <asp:Button ID="btnGetPDFs" runat="server" CssClass="btn btn-success btn-large" Text="Get PDFs" 
            onclick="btnGetPDFs_Click" />

 


    </div>



    </form>
    <div id="dialog-modal" title="Loading">
	
 <div id="progressbar" class="progress progress-striped
     active">
  <div class="bar"
       style="width: 40%;"></div>
</div>

</div>
    <script type="text/javascript">

        $('#btnGetPDFs').click(function () {

            $("#progressbar").show();
            // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
            $("#dialog:ui-dialog").dialog("destroy");

            $("#dialog-modal").dialog({
                height: 140,
                modal: true
            });


        });


        $(document).ready(function () {

            $('#btnGetPDFs').button();
            $("#progressbar").hide();

   
        });
    
    </script>

</body>
</html>
