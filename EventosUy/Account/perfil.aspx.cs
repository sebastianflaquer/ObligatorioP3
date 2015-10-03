using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_perfil_empresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            cargarPerfil();
        }
        else {
            Response.Redirect("../Account/Login"); //Si no esta logeado
        }
    }

    private void cargarPerfil()
    {
        if (Convert.ToInt32(Session["idRol"]) == 1)//Empresa
        {
            this.empresaPerfil.Visible = true;
        }
        else{
            this.adminPerfil.Visible = true;
        }
    }

}