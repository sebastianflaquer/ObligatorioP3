using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using EventosUy;

public partial class Account_Register : Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

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