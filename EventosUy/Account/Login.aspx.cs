﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using EventosUy;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            Empresa aux = Empresa.Instancia.usuarioValido(this.UserName.Text, this.Password.Text);
            if (aux != null)
            {
                Session["logueado"] = true;
                //Session["nombre"] = Empresa.Instancia.Nombre.ToString();
                Session["email"] = aux.MailPublico.ToString();
                Session["idRol"] = aux.idRol;
                Response.Redirect("../");
            }
            else
            {
                //Usuario inexistente
                this.errorField.Visible = true;
                this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Usuario inexistente</span></div>";
            }
        }
}