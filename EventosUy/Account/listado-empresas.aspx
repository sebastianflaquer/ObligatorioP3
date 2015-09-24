<%@ Page Title="Listado de Empresas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="listado-empresas.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <hr />

    <!-- Listado de Empresa -->
    <h2><%: Title %></h2>
        
    <div class="md-content-tebale-empresa">
        <asp:GridView ID="gridListarEmpresas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowCommand="gridListarEmpresas_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="MailPublico" HeaderText="Mail Principal" />
            <asp:BoundField DataField="MailsAdicionales" HeaderText="Mails Adicionales" />
            <asp:BoundField DataField="URL" HeaderText="URL" />
            <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />
        </Columns>
        </asp:GridView>
    </div>
    <!-- END listado de empresa -->

</asp:Content>

