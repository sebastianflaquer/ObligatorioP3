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

    private string mNombre { get; set; }
    private string mTelefono { get; set; }
    private string mMailPublico { get; set; }
    private string mPassword { get; set; }
    private string mMailsAdicionales { get; set; }
    private string mUrl { get; set; }

    #endregion

    //Lo instanciamos para poder usarlo
    private static Empresa mInstancia;
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


    //Guargua el objeto Empresa
    public int GuardarEmpresa(string Nombre, string Telefono, string MailPublico, string MailsAdicionales, string Url, string Password)
    {
        //string de conexion
        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        //string config = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString; //chequee nombre de servidor, Base de datos y usuario de Sqlserver


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

    public static List<Empresa> listarEmpresas()
    {
        List<Empresa> lst = new List<Empresa>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Restaurantes_SelectAll";//indico el nombre del procedimiento almacenado a ejecutar

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
            r.mNombre = drResults["nombreEmpresa"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
            r.mTelefono = drResults["telEmpresa"].ToString();
            r.mTelefono = drResults["mailPrimario"].ToString();
            r.mTelefono = drResults["mailAdicional"].ToString();
            r.mTelefono = drResults["Url"].ToString();
            lst.Add(r);
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }
    //
    // TODO: Agregar aquí la lógica del constructor
    //

}