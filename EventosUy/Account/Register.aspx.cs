using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using EventosUy;

public partial class Account_Register : Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        Empresa.Instancia.GuardarUsuario("1@hola.com", "123456") ;
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
            EmpresaPassword.Text,
            EmpresaTelefono.Text,
            EmpresaMailPublico.Text,
            EmpresaMailAdicional.Text,
            EmpresaUrl.Text
        );
    }

    //protected void CreateUser_Click(object sender, EventArgs e)
    //{
    //    var manager = new UserManager();
    //    var user = new ApplicationUser() { UserName = EmpresaName.Text };
    //    IdentityResult result = manager.Create(user, Password.Text);
    //    if (result.Succeeded)
    //    {
    //        IdentityHelper.SignIn(manager, user, isPersistent: false);
    //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
    //    }
    //    else
    //    {
    //        ErrorMessage.Text = result.Errors.FirstOrDefault();
    //    }
    //}
}