using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_busqueda_empresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BuscarEmpresa(object sender, EventArgs e)
    {
        Empresa empresaBuscada = new Empresa();
        
        
        if (empresaBuscada!=null)
        {
            List<Empresa> lst = new List<Empresa>();
            lst.Add(UsuarioEventosUY.mInstancia.BuscarEmpresa(this.txtBuscar.ToString()));
            this.gridEmpresaBuscada.DataSource = lst;
            this.gridEmpresaBuscada.DataBind();
        }

    }



}