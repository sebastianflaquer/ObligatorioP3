<%@ Page Title="Crear Evento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="crear-evento.aspx.cs" Inherits="Account_crear_evento" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Complete el formulario para crear un nevo evento.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <!-- TITULO EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoTitulo" CssClass="col-md-2 control-label">Titulo Evento</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoTitulo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoTitulo" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
            </div>
        </div>
        <!-- END TITULO EVENTO -->

        <!-- PASSWORD EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoDescripcion" CssClass="col-md-2 control-label">Descripcion</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoDescripcion" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoDescripcion" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        <!-- EDN PASSWORD EMPRESA -->

        <!-- CONFIRM PASSWORD EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoNombreArtista" CssClass="col-md-2 control-label">Nombre Artista/s</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoNombreArtista" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoNombreArtista" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
            </div>
        </div>
        <!-- END CONFIRM PASSWORD EMPRESA -->

        <!-- TELEFONO EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoFecha" CssClass="col-md-2 control-label">Fecha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoFecha" TextMode="Date" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoFecha" CssClass="text-danger" ErrorMessage="El campo de telefono es obligatorio." />
            </div>
        </div>
        <!-- END TELEFONO EMPRESA -->
        
        <!-- MAIL PUBLICO EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoHora" CssClass="col-md-2 control-label">Hora</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoHora" TextMode="Time" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoHora" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL PUBLICO EMPRESA-->

        <!-- MAIL ADICIONAL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoNombreLugar" CssClass="col-md-2 control-label">Nombre Lugar</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoNombreLugar" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoNombreLugar" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL ADICIONAL EMPRESA -->

        <!-- URL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoDireccionLugar" CssClass="col-md-2 control-label">Direccion Lugar</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoDireccionLugar" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoDireccionLugar" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END URL EMPRESA -->

        <!-- URL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoImagen" CssClass="col-md-2 control-label">Imagen</asp:Label>
            <div class="col-md-10">
                <asp:FileUpload ID="EventoImagen" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoImagen" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END URL EMPRESA -->

        <!-- URL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoPrecio" CssClass="col-md-2 control-label">Precio</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoPrecio" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END URL EMPRESA -->

        <!-- BTN ALTA EVENTO -->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnAltaEvento" Text="Crear Evento" CssClass="btn btn-default" />
            </div>
        </div>
        <!-- BTN ALTA EVENTO -->

    </div>
</asp:Content>