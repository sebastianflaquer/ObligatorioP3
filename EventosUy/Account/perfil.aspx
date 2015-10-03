<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="perfil.aspx.cs" Inherits="Account_perfil_empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <!-- Listado de Empresa -->
    <h2><%: Title %>.</h2>
    <hr />

    <!-- EMPRESA -->
    <div id="empresaPerfil" visible=false runat="server">

        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div  class="md-content-perfil-empresa" >
                        <div class="bd">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Nombre</label>
                                <input type="text" id="empresaNombre" class="form-control disable" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Telefono</label>
                                <input type="email" id="empresaTelefono" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Mail Principal</label>
                                <input type="text" id="empresaMailPrincipal" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Mails Extras</label>
                                <input type="text" id="empresaMailsExtras" class="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">URL</label>
                                <input type="text" id="empresaURL" class="form-control" />
                            </div>
                            <button type="submit" class="btn btn-primary">Actualizar</button>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <button type="submit" class="btn btn-danger pull-right">Eliminar Cuenta</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END EMPRESA -->

    
    <div id="adminPerfil" class="md-content-perfil-admin" visible=false runat="server">
        <div class="bd">
            <div class="form-group">
                <label for="exampleInputEmail1">Nombre</label>
                <input type="text" id="AdminNombre" class="form-control disable" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Apellido</label>
                <input type="text" id="AdminApellido" class="form-control" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Email</label>
                <input type="text" id="AdminEmail" class="form-control" />
            </div>            
            <div class="form-group">
                <label for="exampleInputEmail1">DirFisica</label>
                <input type="email" id="AdminDireccion" class="form-control" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Telefono</label>
                <input type="email" id="AdminTelefono" class="form-control" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">NroFuncionario</label>
                <input type="text" id="AdminNroFuncionario" class="form-control" disabled />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Cargo</label>
                <input type="text" id="AdminCargo" class="form-control" disabled />
            </div>
            <button type="submit" class="btn btn-primary">Actualizar</button>
        </div>
    </div>
    <!-- END listado de empresa -->

</asp:Content>

