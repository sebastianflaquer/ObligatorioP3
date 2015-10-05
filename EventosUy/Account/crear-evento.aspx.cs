using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_crear_evento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
           
        }
        else
        {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }
    }

    protected void btnAltaEvento(object sender, EventArgs e)
    {

        // FALTA - hay que validar primero la pagina
        //Page.Validate();

        //if(Page.IsValid)
        //{
        // //validar aca que el mail no se repita
        //}
        string mail = Session["email"].ToString();
        //int idRol = Convert.ToInt32(Session["idRol"]);
        //bool nombreExiste = Evento.Instancia.ValidarNombre(EventoTitulo.Text);

        int afectadas = Evento.Instancia.GuardarEvento(
            EventoTitulo.Text,
            EventoDescripcion.Text,
            EventoNombreArtista.Text,
            EventoFecha.Text,
            EventoHora.Text,
            EventoNombreLugar.Text,
            EventoDireccionLugar.Text,
            EventoBarrioLugar.Text,
            EventoCapasidadMaxima.Text,
            EventoImagen.FileContent,
            EventoPrecio.Text,
            mail
        );

        if (afectadas == -1) {
            this.errorField.Visible = true;
            this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>Evento Creado con Exito</span></div>";
        }
    }

    
}