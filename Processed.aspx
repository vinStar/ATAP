<%@ Page Title="" Language="C#" MasterPageFile="~/ATAP.master" AutoEventWireup="true" CodeFile="Processed.aspx.cs" Inherits="Processed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




        <asp:GridView ID="gvProcessed" UseAccessibleHeader="true" CellPadding="5" CellSpacing="0" Width="100%"
           CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
       HeaderStyle-CssClass="navbar-inner"
             runat="server">
             <Columns>
             
             <asp:BoundField DataField="_sFile" HeaderText="File" />

             <asp:TemplateField HeaderText="Job Duration">
             <ItemTemplate>
             <%# Math.Ceiling(TimeSpan.Parse(Eval("_sSpan").ToString()).TotalSeconds) %> Seconds
             </ItemTemplate>
             </asp:TemplateField>
             
             </Columns>
        </asp:GridView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

