using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_listado_eventos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            //EL GRID LLAMA A LISAT EVENTOS
            this.gridListarEventos.DataSource = Empresa.listarEvento();
            //SE CARGAN LOS DATOS EN EL GRID
            this.gridListarEventos.DataBind();
        }
        else
        {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }

    }
    protected void gridListarEventos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            GridViewRow fila = this.gridListarEventos.Rows[int.Parse(e.CommandArgument.ToString())];


            string tituloEvento = fila.Cells[0].Text; //TOMA EL TITULO DE LA CELLS
            Evento.Instancia.borrarEvento(tituloEvento); // LLAMA A BORRAR EVENTO


            this.gridListarEventos.DataSource = Empresa.listarEvento(); //EL GRID LLAMA A LISAT EVENTOS
            this.gridListarEventos.DataBind();//SE CARGAN LOS DATOS EN EL GRID

            //Mensaje no hay tantos
            //this.errorField.Visible = true;
            //this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Well done!  </strong><span>Pedido eliminado correctamente</span></div>";

        }
    }



}