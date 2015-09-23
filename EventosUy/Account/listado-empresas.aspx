<%@ Page Title="Listado Empresas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="listado-empresas.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <hr />    

    <!-- Listado de Empresa -->
    <h2><%: Title %>.</h2>
    
    
    <div  runat="server"></div>
        
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

