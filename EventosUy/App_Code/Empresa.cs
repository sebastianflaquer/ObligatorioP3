using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Empresa
/// </summary>
public class Empresa
{
    #region Atributos

    private string midEmpresa;
    private string mNombre;
    private string mTelefono;
    private string mMailPublico;
    private string mPassword;
    private string mMailsAdicionales;
    private string mUrl;

    #endregion
    #region Propiedades
    public string idEmpresa
    {
        get { return midEmpresa; }
        set { midEmpresa = value; }
    }
    public string Nombre
    {
        get { return mNombre; }
        set { mNombre = value; }
    }
    public string Telefono
    {
        get { return mTelefono; }
        set { mTelefono = value; }
    }
    public string MailPublico
    {
        get { return mMailPublico; }
        set { mMailPublico = value; }
    }
    public string Password
    {
        get { return mPassword; }
        set { mPassword = value; }
    }
    public string MailsAdicionales
    {
        get { return mMailsAdicionales; }
        set { mMailsAdicionales = value; }
    }

    public string Url
    {
        get { return mUrl; }
        set { mUrl = value; }
    }
    #endregion
    

    //Lo instanciamos para poder usarlo
    public static Empresa mInstancia;
    public static Empresa Instancia
    {
        get
        {
            if (Empresa.mInstancia == null)
            {
                Empresa.mInstancia = new Empresa();
            }
            return Empresa.mInstancia;
        }
    }


    //GUARDAR EMPRESA
    public int GuardarEmpresa(string Nombre, string Telefono, string MailPublico, string MailsAdicionales, string Url, string Password)
    {
        //string de conexion
        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        int afectadas = 0;
        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Empresa_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@nombreEmpresa", Nombre));//agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@telEmpresa", Telefono));
                cmd.Parameters.Add(new SqlParameter("@mailPrimario", MailPublico));
                cmd.Parameters.Add(new SqlParameter("@mailAdicional", MailsAdicionales));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cn.Open();//abrimos conexion
                afectadas = cmd.ExecuteNonQuery();//ejecutamos la consulta y capturamos nro de filas afectadas
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            //loguear excepcion
        }
        finally
        {

        }
        return afectadas;
    }

    //BORRAR EMPRESA
    public bool borrarEmpresa(int idEmpresa)
    {
        bool retorno = false;

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {

                //SqlTransaction tr = con.BeginTransaction();
                //cmd.Transaction = tr;
                //this.numero = (int)cmd.ExecuteScalar();

                cmd.Connection = cn;
                cmd.CommandText = "Empresa_EliminarPorId"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", idEmpresa));//agregamos parametros para la consulta
                cn.Open();//abrimos conexion
                cmd.ExecuteNonQuery();
                retorno = true;
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            //loguear excepcion
        }
        finally
        {

        }
        return retorno;
    }

    //BUSCAR EMPRESA
    public List<Empresa> BuscarEmpresa(string txtbuscar)
    {
        List<Empresa> lst = new List<Empresa>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresas_SelectAll";//indico el nombre del procedimiento almacenado a ejecutar

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            Empresa r = new Empresa();
            r.midEmpresa = drResults["idEmpresa"].ToString();
            r.mNombre = drResults["nombreEmpresa"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
            r.mTelefono = drResults["telEmpresa"].ToString();
            r.mMailPublico = drResults["mailPrimario"].ToString();
            r.mMailsAdicionales = drResults["mailAdicional"].ToString();
            r.mUrl = drResults["Url"].ToString();

            if (r.mNombre == txtbuscar)
            {
                lst.Add(r);
            }
            
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }


    //LISTAR EMPRESAS
    public static List<Empresa> listarEmpresas()
    {
        List<Empresa> lst = new List<Empresa>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresas_SelectAll";//indico el nombre del procedimiento almacenado a ejecutar

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            Empresa r = new Empresa();
            r.midEmpresa = drResults["idEmpresa"].ToString();
            r.mNombre = drResults["nombreEmpresa"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
            r.mTelefono = drResults["telEmpresa"].ToString();
            r.mMailPublico = drResults["mailPrimario"].ToString();
            r.mMailsAdicionales = drResults["mailAdicional"].ToString();
            r.mUrl = drResults["Url"].ToString();
            lst.Add(r);
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }

    //LISTAR EVENTOS
    public static List<Evento> listarEvento()
    {
        List<Evento> lst = new List<Evento>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Evento_SelectAll";//indico el nombre del procedimiento almacenado a ejecutar

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (drResults.Read())
        {
            //string retornoPrecios = "";
            Evento r = new Evento();
            r.Titulo = drResults["Titulo"].ToString();
            r.Descripcion = drResults["Descripcion"].ToString();
            r.NombreArtistas = drResults["Nombreartista"].ToString();
            //r.Fecha = drResults["fecha"].ToString;
            r.Hora = drResults["hora"].ToString();
            r.NombreLugar = drResults["nombreLugar"].ToString();
            r.DireccionLugar = drResults["direccionLugar"].ToString();
            //r.Imagen =
            //r.Imagen = drResults["imagen"].ToString();
            //r.Precio.Add(drResults["precio"].ToString());
            //r.Precio = drResults["precio"].ToString();
            r.Estado = drResults["estado"].ToString();
            //r.NombreEmpresa = drResults["nombreEmpresa"].ToString();
            lst.Add(r);
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }

    //CARGAR DATOS
    //public string CargarDatos()
    //{
    //    List<Empresa> listarEmpresas = Empresa.listarEmpresas();
    //    string retorno = "";
    //    foreach (Empresa unaEmpresa in listarEmpresas)
    //    {

    //        retorno += "<tr><th scope='row'>" + "</th>";
    //        retorno += "<td>" + unaEmpresa.mNombre + "</td>";
    //        retorno += "<td>" + unaEmpresa.mTelefono + "</td>";
    //        retorno += "<td>" + unaEmpresa.mMailPublico + "</td>";
    //        retorno += "<td>" + unaEmpresa.mMailsAdicionales + "</td>";
    //        retorno += "<td>" + unaEmpresa.mUrl + "</td>";

    //        //Cierra el Row
    //        retorno += "</tr>";
    //    }
    //    return retorno;
    //}

       
}