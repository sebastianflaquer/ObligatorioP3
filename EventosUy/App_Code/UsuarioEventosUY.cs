using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UsuarioEventosUY
/// </summary>
public class UsuarioEventosUY
{
    #region Atributos

    private string mNombre;    
    private string mApellido;    
    private string mEmail;    
    private string mPassword;    
    private int mNroFuncionario;    
    private string mDirFisica;    
    private string mTelefono;    
    private string mCargo;    

    #endregion
    #region Propiedades
    public string Nombre
    {
        get { return mNombre; }
        set { mNombre = value; }
    }
    public string Apellido
    {
        get { return mApellido; }
        set { mApellido = value; }
    }
    public string Email
    {
        get { return mEmail; }
        set { mEmail = value; }
    }
    public string Password
    {
        get { return mPassword; }
        set { mPassword = value; }
    }
    public int NroFuncionario
    {
        get { return mNroFuncionario; }
        set { mNroFuncionario = value; }
    }
    public string DirFisica
    {
        get { return mDirFisica; }
        set { mDirFisica = value; }
    }
    public string Telefono
    {
        get { return mTelefono; }
        set { mTelefono = value; }
    }
    public string Cargo
    {
        get { return mCargo; }
        set { mCargo = value; }
    }
    #endregion

    //Guargua el objeto Empresa
    public int GuardarUsuarioEventosUY()
    {
        //string de conexion
        string config = @"Server=.\SQLEXPRESS;DataBase=EventosUY;Trusted_Connection=true;"; //chequee nombre de servidor, Base de datos y usuario de Sqlserver
        SqlConnection con = new SqlConnection(config); //creamos y configuramos la conexion

        int afectadas = 0;
        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = con;
                cmd.CommandText = "usuarioEventosUY_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@NroFuncionario", this.mNroFuncionario));//agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@NombreEuy", this.mNombre));
                cmd.Parameters.Add(new SqlParameter("@ApellidoEuy", this.mApellido));
                cmd.Parameters.Add(new SqlParameter("@EmailEuy", this.mEmail));
                cmd.Parameters.Add(new SqlParameter("@PasswordEuy", this.mPassword));
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.mTelefono));
                cmd.Parameters.Add(new SqlParameter("@Cargo", this.mCargo));
                con.Open();//abrimos conexion
                afectadas = cmd.ExecuteNonQuery();//ejecutamos la consulta y capturamos nro de filas afectadas
                con.Close();//cerramos conexion
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



    public bool borrarUsuario(string nombreUsuario){
        bool retorno = false;

        //string de conexion
        string config = @"Server=.\SQLEXPRESS;DataBase=EventosUY;Trusted_Connection=true;"; //chequee nombre de servidor, Base de datos y usuario de Sqlserver
        SqlConnection con = new SqlConnection(config); //creamos y configuramos la conexion


        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = con;
                cmd.CommandText = "Empresa_EliminarPorNombre"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@nombreEmpresa", nombreUsuario));//agregamos parametros para la consulta
                con.Open();//abrimos conexion
                retorno = true;
                con.Close();//cerramos conexion
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


    public Empresa BuscarEmpresa(string nombreEmpresa){

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresa_BuscarPorNombre";//indico el nombre del procedimiento almacenado a ejecutar

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
            if (drResults["nombreEmpresa"].ToString()==nombreEmpresa)
            {
                Empresa r = new Empresa();
                r.Nombre = drResults["nombreEmpresa"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
                r.Telefono = drResults["telEmpresa"].ToString();
                r.MailPublico = drResults["mailPrimario"].ToString();
                r.MailsAdicionales = drResults["mailAdicional"].ToString();
                r.Url = drResults["Url"].ToString();
                return r;
            }
            
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;




        return retorno;
    }

    public UsuarioEventosUY()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}