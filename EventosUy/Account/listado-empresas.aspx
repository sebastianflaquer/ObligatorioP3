<%@ Page Title="Listado Empresas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="listado-empresas.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <hr />    

    <!-- Listado de Empresa -->
    <h2><%: Title %>.<asp:GridView ID="GridEmpresas" runat="server" AutoGenerateColumns="False" DataKeyNames="idEmpresa" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="idEmpresa" HeaderText="idEmpresa" InsertVisible="False" ReadOnly="True" SortExpression="idEmpresa" />
            <asp:BoundField DataField="nombreEmpresa" HeaderText="nombreEmpresa" SortExpression="nombreEmpresa" />
            <asp:BoundField DataField="telEmpresa" HeaderText="telEmpresa" SortExpression="telEmpresa" />
            <asp:BoundField DataField="mailPrimario" HeaderText="mailPrimario" SortExpression="mailPrimario" />
            <asp:BoundField DataField="mailAdicional" HeaderText="mailAdicional" SortExpression="mailAdicional" />
            <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EventosUYConnectionString %>" SelectCommand="SELECT * FROM [Empresa]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EventosUYConnectionString %>" SelectCommand="SELECT [idEmpresa] FROM [Empresa] ORDER BY [idEmpresa]"></asp:SqlDataSource>
    </h2>
        
    <div class="md-content-tebale-empresa">
        <table class="table table-bordered">
          <thead>
            <tr>
              <th>#</th>
              <th>Nombre</th>
              <th>Telefono</th>
              <th>Mail Principal</th>
              <th>Mail/s Adicional/es</th>
              <th>Url</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody id="pepe" runat="server">
            <tr>
              <th scope="row">1</th>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td>
                <button type="button" class="btn btn-info">Ver Perfil</button>
                <button type="button" class="btn btn-danger">Eliminar</button>
              </td>
            </tr>
          </tbody>
        </table>
    </div>
    <!-- END listado de empresa -->

</asp:Content>

