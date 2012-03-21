<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ATAP.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



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


    <div id="dialog-modal" title="Loading">
	
 <div id="progressbar" class="progress progress-striped
     active">
  <div class="bar"
       style="width: 99%;"></div>
</div>

</div>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">

   <script type="text/javascript">

       $('#btnGetPDFs').click(function () {

           $("#progressbar").show();
           // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
           $("#dialog:ui-dialog").dialog("destroy");

           $("#dialog-modal").dialog({
               height: 100,
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

</asp:Content>

