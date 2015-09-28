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

    private string mIdEmpresa;
    private string mNombreEmpresa;
    private string mTitulo;
    private string mDescripcion;    
    private string mNombreArtistas;    
    private DateTime mFecha;    
    private string mHora;    
    private string mNombreLugar;    
    private string mDireccionLugar;    
    private string mImagen;
    private string mPrecio;   
    private string mEstado;
    
    #endregion
    #region Propiedades

    public string IdEmpresa
    {
        get { return mIdEmpresa; }
        set { mIdEmpresa = value; }
    }
    public string NombreEmpresa
    {
        get { return mNombreEmpresa; }
        set { mNombreEmpresa = value; }
    }
    public string Titulo
    {
        get { return mTitulo; }
        set { mTitulo = value; }
    }
    public string Descripcion
    {
        get { return mDescripcion; }
        set { mDescripcion = value; }
    }
    public string NombreArtistas
    {
        get { return mNombreArtistas; }
        set { mNombreArtistas = value; }
    }
    public DateTime Fecha
    {
        get { return mFecha; }
        set { mFecha = value; }
    }
    public string Hora
    {
        get { return mHora; }
        set { mHora = value; }
    }
    public string NombreLugar
    {
        get { return mNombreLugar; }
        set { mNombreLugar = value; }
    }
    public string DireccionLugar
    {
        get { return mDireccionLugar; }
        set { mDireccionLugar = value; }
    }
    public string Imagen
    {
        get { return mImagen; }
        set { mImagen = value; }
    }
    public string Precio
    {
        get { return mPrecio; }
        set { mPrecio = value; }
    }
    public string Estado
    {
        get { return mEstado; }
        set { mEstado = value; }
    }
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

    //Guargua el objeto Evento
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
                //string retornoPrecios = "";

                //@Titulo varchar(30),
                //@Descripcion varchar(300),
                //@NombreArtista varchar(300),
                //@Fecha date,
                //@Hora time(7),
                //@NombreLugar varchar(50),
                //@DireccionLugar varchar(50),
                //@Imagen varbinary(max),
                //@Precio varchar(300),
                //@Estado char(1),
                //@idEmpresa int

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
                cmd.Parameters.Add(new SqlParameter("@Precio",Precio));
                cmd.Parameters.Add(new SqlParameter("@Estado", "A"));
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", "1"));

                // CREAR FOREACH PARA QUE EL PRECIO SEA UNA LISTADO
                //foreach (string unPrecio in this.mPrecio)
                //{
                //    retornoPrecios = retornoPrecios + " " +unPrecio;
                //}
                //cmd.Parameters.Add(new SqlParameter("@Precio", retornoPrecios));//aca va la lista
                //Falta guardar en la DBO quien es la empresa que lo guarda
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

    //Baja de evento - Borrar Evento
    public bool borrarEvento(string tituloEvento)
    {
        bool retorno = false;

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Evento_EliminarPorTitulo"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@tituloEvento", tituloEvento));//agregamos parametros para la consulta
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

}