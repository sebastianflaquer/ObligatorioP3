using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using EventosUy;

public partial class Account_Register : Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Boolean)Session["logueado"]) //Si esta logeado
        {
            if (Convert.ToInt32(Session["idRol"]) == 2)//Si es un Administrador
            {
                //Puede registrar una empresa
            }
            else {
                Response.Redirect("../");//No puede registar una empresa
            } 
        }
        else //Si no esta logeado
        {
            //Puede registrar una empresa
        }
    }

    protected void btnAltaEmpresa(object sender, EventArgs e)
    {

        // FALTA - hay que validar primero la pagina
        //Page.Validate();

        //if(Page.IsValid)
        //{
        // //validar aca que el mail no se repita
        //}

        Empresa.Instancia.GuardarEmpresa(
            EmpresaName.Text,
            EmpresaTelefono.Text,
            EmpresaMailPublico.Text,
            EmpresaMailAdicional.Text,
            EmpresaUrl.Text,
            EmpresaPassword.Text
        );
    }

}