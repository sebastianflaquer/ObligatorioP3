using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_crear_evento : System.Web.UI.Page
{


    protected void btnAltaEvento(object sender, EventArgs e)
    {

        // FALTA - hay que validar primero la pagina
        //Page.Validate();

        //if(Page.IsValid)
        //{
        // //validar aca que el mail no se repita
        //}
        Evento.Instancia.GuardarEvento(
            EventoTitulo.Text,
            EventoDescripcion.Text,
            EventoNombreArtista.Text,
            EventoFecha.Text,
            EventoHora.Text,
            EventoNombreLugar.Text,
            EventoDireccionLugar.Text,
            EventoImagen.FileContent,
            EventoPrecio.Text            
        );
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}