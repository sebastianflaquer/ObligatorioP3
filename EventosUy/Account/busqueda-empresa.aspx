<%@ Page Title="Busqueda Empresa" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="busqueda-empresa.aspx.cs" Inherits="Account_busqueda_empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <hr />    

    <!-- Listado de Empresa -->
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-6">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="BuscarEmpresa" Text="Buscar" CssClass="btn btn-default" />
                            <asp:GridView ID="gridEmpresaBuscada" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                    <asp:BoundField DataField="MailPublico" HeaderText="Mail Principal" />
                                    <asp:BoundField DataField="MailsAdicionales" HeaderText="Mails Adicionales" />
                                    <asp:BoundField DataField="Url" HeaderText="URL" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>

