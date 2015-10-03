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

    private int midEmpresa;
    private string mNombre;
    private string mTelefono;
    private int midUsuario;
    private string mMailPublico;
    private string mPassword;
    private string mMailsAdicionales;
    private string mUrl;
    private int midRol;
    

    #endregion
    #region Propiedades
    public int idEmpresa
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
    public int idUsuario
    {
        get { return midUsuario; }
        set { midUsuario = value; }
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
    }    public int idRol
    {
        get { return midRol; }
        set { midRol = value; }
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

        int idUsuario = 0;
        int afectadas = 0;

        //declaramos  el Transaction
        SqlTransaction trn = null;
        
        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Usuarios_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@mailPrimario", MailPublico));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cn.Open(); //abrimos conexion
                
                //CREAMOS LA TRANSACCION
                trn = cn.BeginTransaction();//iniciamos la transaccion 
                cmd.Transaction = trn;

                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());//Usamos el ExecuteScalar para devolver el IdUsuario

                cmd.CommandText = "Empresa_Insert";//Pisamos el CommandText
                cmd.Parameters.Clear();//Limpiamos los Parametros
                cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre)); //agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mails", MailsAdicionales));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

                afectadas = cmd.ExecuteNonQuery(); //ejecutamos la consulta y capturamos nro de filas afectadas
                trn.Commit();//Si todo sale bien Ejecuta las consultas                
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            trn.Rollback();//Si hay un error Hace un RollBack para dejar sin efecto las consultas
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
                cn.Close(); //cerramos la conexion
        }
        return afectadas;
        //return afectadas;
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
            r.midEmpresa = Convert.ToInt32(drResults["idEmpresa"]);
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
            r.midEmpresa = Convert.ToInt32(drResults["idEmpresa"]);
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
    

    //USUARIO VALIDO
    //public Empresa usuarioValido(string UserName, string Password)
    //{

    //    SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
    //    string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
    //    cn.ConnectionString = cadenaConexion;

    //    Empresa unaEmpresa = new Empresa();
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
    //    cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

    //    SqlDataReader drResults;

    //    cmd.Connection = cn;
    //    cn.Open();//abrimos la conexion
    //    drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
    //    //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre
        
    //    while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
    //    {
    //        string MailPublicoLectura = drResults["MailUsuario"].ToString();
    //        string PasswordLectura    =  drResults["PassUsuario"].ToString();

    //        if (MailPublicoLectura == UserName && PasswordLectura == Password)
    //        {
    //            Empresa r = new Empresa();
    //            r.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
    //            r.MailPublico = drResults["MailUsuario"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
    //            r.Password = drResults["PassUsuario"].ToString();
    //            r.idRol = Convert.ToInt32(drResults["idRol"]);
    //            unaEmpresa = r;
    //            unaEmpresa = cargarDatosEmpresa(unaEmpresa);
    //            return unaEmpresa;
    //        }

    //    }
    //    drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
    //    cn.Close(); //cerramos la conexion explicitamente
    //    return unaEmpresa;
    //}

    //CARGAR DATOS EMPRESA
    public Empresa cargarDatosEmpresa(string UserName)
    {
        
        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        Empresa unaEmpresa = new Empresa();

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            string MailPublicoLectura = drResults["MailUsuario"].ToString();
            string PasswordLectura = drResults["PassUsuario"].ToString();

            if (MailPublicoLectura == UserName)
            {
                Empresa r = new Empresa();
                r.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
                r.MailPublico = drResults["MailUsuario"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
                r.Password = drResults["PassUsuario"].ToString();
                r.idRol = Convert.ToInt32(drResults["idRol"]);
                unaEmpresa = r;
                unaEmpresa = cargarDatosDeEmpresa(unaEmpresa);
                return unaEmpresa;
            }

        }

        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return unaEmpresa;
        
    }

    //CARGAR DATOS DE EMPRESA
    public Empresa cargarDatosDeEmpresa(Empresa unaEmpresa)
    {

        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresa_CargarDatos";

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())
        { //Mientras tenga datos para leer
            int idUsuario = Convert.ToInt32(drResults["idUsuario"]);
            if (unaEmpresa.idUsuario == idUsuario)
            {
                unaEmpresa.idEmpresa = Convert.ToInt32(drResults["idEmpresa"]);
                unaEmpresa.Nombre = drResults["Nombre"].ToString();
                unaEmpresa.Telefono = drResults["Telefono"].ToString();
                unaEmpresa.MailsAdicionales = drResults["Mails"].ToString();
                unaEmpresa.Url = drResults["Url"].ToString();
                return unaEmpresa;
            }
        }
        return unaEmpresa;
    }
    
}