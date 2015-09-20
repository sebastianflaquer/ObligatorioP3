using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Evento
/// </summary>
public class Evento
{
    #region Atributos

    private string mEmpresaId { get; set; }
    private string mTitulo { get; set; }
    private string mNombreArtistas { get; set; }
    private DateTime mFecha { get; set; }
    private string mHora { get; set; }
    private string mNombreLugar { get; set; }
    private string mDireccionLugar { get; set; }
    private string mImagen { get; set; }
    //private string List<string> mPrecio { get; set; };
    private string mEstado { get; set; }


    #endregion

    //Guargua el objeto Empresa
    public int GuardarEvento()
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
                cmd.CommandText = "Evento_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@Titulo", this.mTitulo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", this.mNombreArtistas));
                cmd.Parameters.Add(new SqlParameter("@NombreArtista", this.mFecha));
                cmd.Parameters.Add(new SqlParameter("@fecha", this.mHora));
                cmd.Parameters.Add(new SqlParameter("@hora", this.mNombreLugar));
                cmd.Parameters.Add(new SqlParameter("@nombreLugar", this.mDireccionLugar));
                cmd.Parameters.Add(new SqlParameter("@direccionLugar", this.mImagen));
                //cmd.Parameters.Add(new SqlParameter("@precio", this.mPrecio));//aca va la lista
                cmd.Parameters.Add(new SqlParameter("@estado", this.mEstado));
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





	public Evento()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}