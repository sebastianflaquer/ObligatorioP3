using System;
using System.Collections.Generic;
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

    private string mNombre { get; set; }
    private string mApellido { get; set; }
    private string mEmail { get; set; }
    private string mPassword { get; set; }
    private int mNroFuncionario { get; set; }
    private string mDirFisica { get; set; }
    private string mTelefono { get; set; }
    private string mCargo { get; set; }

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




    public UsuarioEventosUY()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}