using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            this.gridListarEmpresas.DataSource = Empresa.listarEmpresas();
            this.gridListarEmpresas.DataBind();
        }
        else
        {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }
    }

    protected void gridListarEmpresas_RowCommand(object sender, GridViewCommandEventArgs e){         
        if (e.CommandName == "Eliminar")
         {   
             GridViewRow fila = this.gridListarEmpresas.Rows[int.Parse(e.CommandArgument.ToString())];
             
             string idEmpresa = fila.Cells[0].Text;
             int idEmpresaNum = Int32.Parse(idEmpresa); //Paso el Strgin a INT - "1" a 1
             Empresa.Instancia.borrarEmpresa(idEmpresaNum);

             this.gridListarEmpresas.DataSource = Empresa.listarEmpresas();
             this.gridListarEmpresas.DataBind();

             //Mensaje no hay tantos
             //this.errorField.Visible = true;
             //this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><strong>Well done!  </strong><span>Pedido eliminado correctamente</span></div>";

         }
    }
}