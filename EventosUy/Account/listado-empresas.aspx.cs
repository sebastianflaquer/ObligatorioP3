using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Default : System.Web.UI.Page
{

    public string CargarDatos()
    {
        List<Empresa> listarEmpresas = Empresa.listarEmpresas();
        string retorno = "";
        foreach (Empresa unaEmpresa in listarEmpresas)
        {

            retorno += "<tr><th scope='row'>" + "</th>";
            retorno += "<td>" + unaEmpresa.mNombre + "</td>";
            retorno += "<td>" + unaEmpresa.mTelefono + "</td>";
            retorno += "<td>" + unaEmpresa.mMailPublico + "</td>";
            retorno += "<td>" + unaEmpresa.mMailsAdicionales + "</td>";
            retorno += "<td>" + unaEmpresa.mUrl + "</td>";

            //Cierra el Row
            retorno += "</tr>";
        }
        return retorno;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        pepe.InnerHtml=CargarDatos();
    }
}