<%@ Page Title="" Language="C#" MasterPageFile="~/ATAP.master" AutoEventWireup="true" CodeFile="Processed.aspx.cs" Inherits="Processed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <h1>Produced Volumes</h1>
     <asp:GridView ID="gvVolPDF" UseAccessibleHeader="true" CellPadding="5" CellSpacing="0" Width="100%"
           CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
       HeaderStyle-CssClass="navbar-inner" runat="server">
       <Columns>

       <asp:TemplateField HeaderText="Download">
       <ItemTemplate>
       <a href="Temp/<%=Session["sDir"].ToString() %>/<%#Eval("Name") %>" target="_blank">
           <img src="Images/pdf_download.png" alt="download" /></a>
       </ItemTemplate>
       </asp:TemplateField>

        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Length" HeaderText="Byte Size" />
        <asp:BoundField DataField="DirectoryName" HeaderText="DirectoryName" />
        <asp:BoundField DataField="CreationTime" HeaderText="CreationTime" />

       </Columns>
    </asp:GridView>


     <h1>Processed PDF's</h1>

        <asp:GridView ID="gvProcessed" UseAccessibleHeader="true" CellPadding="5" CellSpacing="0" Width="100%"
           CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
       HeaderStyle-CssClass="navbar-inner"
             runat="server">
             <Columns>
             
             
             <asp:BoundField DataField="_Volume" HeaderText="Volume" />
             <asp:BoundField DataField="_Section" HeaderText="Section" />
             <asp:BoundField DataField="_sFile" HeaderText="File" />

             <asp:TemplateField HeaderText="Job Duration">
             <ItemTemplate>
             <%# Math.Ceiling(TimeSpan.Parse(Eval("_sSpan").ToString()).TotalSeconds) %> Seconds
             </ItemTemplate>
             </asp:TemplateField>

             <asp:BoundField DataField="_sPath" HeaderText="Path" />
             
             </Columns>
        </asp:GridView>

        <div class="row">
            <div class="span12">
                <div class="well">



                    <a class="btn btn-primary btn-large" href="#"><i class="icon-print icon-white"></i> Print</a>
                    <a class="btn btn-success btn-large" href="Default.aspx"><i class="icon-ok-sign icon-white"></i> Go Back</a>

           

                </div>
            </div>
        </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

