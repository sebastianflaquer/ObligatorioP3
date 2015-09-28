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
    public static UsuarioEventosUY mInstancia;
  

    #endregion
    #region Propiedades
    public static UsuarioEventosUY Instancia
    {
        get
        {
            if (UsuarioEventosUY.mInstancia == null)
            {
                UsuarioEventosUY.mInstancia = new UsuarioEventosUY();
            }
            return UsuarioEventosUY.mInstancia;
        }
    }
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

    //Guardar Usuario Euy
    public int GuardarUsuarioEventosUY()
    {


        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        int afectadas = 0;
        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "usuarioEventosUY_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@NroFuncionario", this.mNroFuncionario));//agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@NombreEuy", this.mNombre));
                cmd.Parameters.Add(new SqlParameter("@ApellidoEuy", this.mApellido));
                cmd.Parameters.Add(new SqlParameter("@EmailEuy", this.mEmail));
                cmd.Parameters.Add(new SqlParameter("@PasswordEuy", this.mPassword));
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.mTelefono));
                cmd.Parameters.Add(new SqlParameter("@Cargo", this.mCargo));
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
       
    public UsuarioEventosUY()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}