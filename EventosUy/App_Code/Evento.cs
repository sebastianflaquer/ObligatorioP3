using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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


    //Lo instanciamos para poder usarlo
    private static Evento mInstancia;
    public static Evento Instancia
    {
        get
        {
            if (Evento.mInstancia == null)
            {
                Evento.mInstancia = new Evento();
            }
            return Evento.mInstancia;
        }
    }

    //Guargua el objeto Empresa
    public void GuardarEvento(string Titulo, string Descripcion, string NombreArtista, string Fecha, string Hora, string NombreLugar, string DireccionLugar, System.IO.Stream Imagen, string Precio)
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
                cmd.CommandText = "Evento_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@Titulo", Titulo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@NombreArtista", NombreArtista));
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                cmd.Parameters.Add(new SqlParameter("@Hora", Hora));
                cmd.Parameters.Add(new SqlParameter("@NombreLugar", NombreLugar));
                cmd.Parameters.Add(new SqlParameter("@DireccionLugar", DireccionLugar));
                cmd.Parameters.Add(new SqlParameter("@Imagen", Imagen));
                cmd.Parameters.Add(new SqlParameter("@Precio", Precio));//aca va la lista
                cmd.Parameters.Add(new SqlParameter("@Estado", "A"));
                //cmd.Parameters.Add(new SqlParameter("@idEmpresa", "1"));
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
    }

}