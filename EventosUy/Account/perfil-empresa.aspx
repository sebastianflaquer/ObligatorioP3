<%@ Page Title="Perfil Empresa" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="perfil-empresa.aspx.cs" Inherits="Account_perfil_empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <hr />    

    <!-- Listado de Empresa -->
    <h2><%: Title %>.</h2>

    <div class="md-content-perfil-empresa">
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

