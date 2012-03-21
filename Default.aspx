<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>ATAP</title>
  
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
    <link href="Styles/checkboxes.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    

</head>
<body>
    <form id="form1" runat="server">


    <div class="navbar navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container">
      <div style="padding:25px">
          <a class="brand" href="#">ATAP Project</a>
         </div>
          
        </div>
      </div>
    </div>

    <div class="container">



    


     <ul class="nav nav-pills">
              <li class="active">
    
              <a href="Default.aspx">
              <i class="icon-search icon-white"></i> Appeals Lookup</a></li>
               <li>
              <a href="Default.aspx#">Recent Jobs</a>
               </li> 
                <li>
              <a href="Default.aspx#">Print Page</a>
               </li> 
            </ul>


            <div class="alert alert-info">
            The max pages for each volume is <b>100</b> pages.
            </div>
  

        <asp:GridView ID="gvDocsToPDF" UseAccessibleHeader="true" CellPadding="5" CellSpacing="0" Width="100%"
           CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
       HeaderStyle-CssClass="navbar-inner"
             runat="server">
             <Columns>
             <asp:TemplateField>
             <ItemTemplate>
       
                 <asp:CheckBox ID="cbSelect"  AutoPostBack="true"   OnCheckedChanged="cbSelect_CheckedChanged" Checked="true" runat="server">
                 </asp:CheckBox>
    


             </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Volume" />
             <asp:TemplateField HeaderText="Section" />
             <asp:BoundField DataField="_sFileName" HeaderText="File Name" />
             <asp:BoundField DataField="_sFileURL" HeaderText="File URL" />
             <asp:BoundField DataField="_iJobOrder" HeaderText="Order" Visible="false" />
             <asp:BoundField DataField="_iPages" HeaderText="Pages" />

             </Columns>
        </asp:GridView>


   
 

 
      <div class="row">
      <div class="span6">
      <div class="well">
            <asp:Button ID="btnGetPDFs" runat="server" CssClass="btn btn-info btn-large" Text="Get PDFs" 
            onclick="btnGetPDFs_Click" />
            </div>
      </div>
      <div class="span6">
       <div class="well">
         <h3>Total PDF Pages</h3>
         <span class="badge badge-inverse"> <asp:Literal ID="ltTotalPgs" runat="server"></asp:Literal></span>
        
        <asp:Literal ID="ltLocalDir" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltFolderDir" Visible="false" runat="server"></asp:Literal>
        </div>
      </div>

  
        

        </div>

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


        $(".mycheckbox").click(function () {

            $(this).attr('checked');

        });

        $(document).ready(function () {

            $('#btnGetPDFs').button();
            $("#progressbar").hide();

   
        });
    
    </script>

</body>
</html>
