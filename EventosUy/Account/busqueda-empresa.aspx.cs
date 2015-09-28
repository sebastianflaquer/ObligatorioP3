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
        List<Empresa> listaEmpresaBuscada = new List<Empresa>();
        string buscar = txtBuscarForm.Text;
        listaEmpresaBuscada = Empresa.Instancia.BuscarEmpresa(buscar);
        
        //Empresa empresaBuscada = new Empresa();
        //listaEmpresaBuscada.Add(empresaBuscada);

        if (listaEmpresaBuscada!= null)
        {
            this.gridEmpresaBuscada.DataSource = listaEmpresaBuscada;
            this.gridEmpresaBuscada.DataBind();
        }
    }

}