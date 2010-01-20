using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Descripción breve de ABMCTask
/// </summary>
public class ABMCTask
{
    public ABMCTask()
    {
    }

    public static int getIdentifierOfTaskById(int id)
    {
        int identifier = 0;
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        try
        {
            commandSql.Connection = sqlConn;
            commandSql = sqlConn.CreateCommand();

            commandSql.CommandText = "SELECT Identificador FROM ProductoTareas WHERE id = @ID ";
            SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
            p_id.Value = id;
            sqlConn.Open();
            System.Data.SqlClient.SqlDataReader DbReader = commandSql.ExecuteReader();

            while (DbReader.Read())
            {
                identifier = Convert.ToInt16((DbReader["identificador"].ToString()));
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception Obtener identificador ABMCTask");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }

        return identifier;
    }

    public int getLastIdentifier()
    {
        
        int max = 0;
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        try
        {
            commandSql.Connection = sqlConn;
            commandSql = sqlConn.CreateCommand();

            commandSql.CommandText = "SELECT Identificador FROM ProductoTareas WHERE Identificador = (SELECT MAX(Identificador)  FROM ProductoTareas) ";
            sqlConn.Open();
            System.Data.SqlClient.SqlDataReader DbReader = commandSql.ExecuteReader();

            while (DbReader.Read())
            {
                max = Convert.ToInt16((DbReader["identificador"].ToString()));
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener ultimo identificador ABMCTask");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }

        max = max + 1;
        return max;
    }

    public Task getTask(int id)
    {
        String sql = "SELECT "+
                        "Id,"+
                        "Identificador,"+
                        "Autor,"+
                        "FechaCreacion,"+
                        "Titulo," +
                        "Responsable," +
                        "Usuario," +
                        "Habilitada," +
                        "Descripcion " +
                        " FROM "+
                        " ProductoTareas " +
                        " WHERE " +
                        " Id = @ID;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_id.Value = id;
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            sqlConn.Close();
            da.Fill(ds, "Atributo");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtenerAtributo ABMCTask");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        Task salida = new Task();
        if (ds.Tables.Count == 0) return null;
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            salida.Id = id;
            salida.Identificador = Convert.ToInt16(row[1].ToString());
            salida.Autor = row[2].ToString();
            salida.FechaCreacion = DateTime.Parse(row[3].ToString());
            salida.Titulo = row[4].ToString();
            salida.Responsable = row[5].ToString();
            salida.Usuario = row[6].ToString();
            salida.Habilitada = Convert.ToBoolean(row[7].ToString());
            salida.Descripcion = row[8].ToString();
            return salida;
        }
        else
        {
            return null;
        }
        
    }

    public Boolean updateTask(Task guardar)
    {
        String sql = " UPDATE ProductoTareas " +
                    " SET " +
                    " Identificador = @IDENTIFICADOR," +
                    " Autor = @AUTOR," +
                    " FechaCreacion = @FECHACREACION," +
                    " Titulo = @TITULO," +
                    " Responsable = @RESPONSABLE, " +
                    " Usuario = @USUARIO, " +
                    " Habilitada = @HABILITADA," +
                    " Descripcion = @DESCRIPCION" +
                    " WHERE " +
                    " Id = @ID;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.CommandText = sql;
        SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_id.Value = guardar.Id;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_identificador.Value = guardar.Identificador;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = guardar.Autor;
        SqlParameter p_fechaCreacion = commandSql.Parameters.Add("FECHACREACION", SqlDbType.DateTime);
        p_fechaCreacion.Value = guardar.FechaCreacion;
        SqlParameter p_titulo = commandSql.Parameters.Add("TITULO", SqlDbType.NChar);
        p_titulo.Value = guardar.Titulo;
        SqlParameter p_responsable = commandSql.Parameters.Add("RESPONSABLE", SqlDbType.NChar);
        p_responsable.Value = guardar.Responsable;
        SqlParameter p_usuario = commandSql.Parameters.Add("USUARIO", SqlDbType.NChar);
        p_usuario.Value = guardar.Usuario;
        SqlParameter p_habilitada = commandSql.Parameters.Add("HABILITADA", SqlDbType.Bit);
        p_habilitada.Value = guardar.Habilitada;
        SqlParameter p_descripcion = commandSql.Parameters.Add("DESCRIPCION", SqlDbType.NChar);
        p_descripcion.Value = guardar.Descripcion;
        Log.saveInLog("--------------Update Task ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        foreach (SqlParameter item in commandSql.Parameters)
        {

            Log.saveInLog(item.ParameterName);
            Log.saveInLog(item.Value.ToString());
        }
        commandSql.Connection = sqlConn;
        try
        {
            sqlConn.Open();
            commandSql.ExecuteNonQuery();
            salida = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception  updateAtributo ABMCTask");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    public Boolean saveTask(Task guardar)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "ProductoTareas " +
            "(" +
                "Identificador," +
                "Autor," +
                "FechaCreacion," +
                "Titulo," +
                "Responsable," +
                "Usuario," +
                "Habilitada," +
                "Descripcion" +
            ")" +
            "VALUES"+
            "(" +
                "@IDENTIFICADOR," +
                "@AUTOR," +
                "@FECHACREACION," +
                "@TITULO," +
                "@RESPONSABLE,"+
                "@USUARIO," +
                "@HABILITADA," +
                "@DESCRIPCION" +
            ");";
        commandSql.CommandText = sql;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_identificador.Value = guardar.Identificador;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = guardar.Autor;
        SqlParameter p_fechaCreacion = commandSql.Parameters.Add("FECHACREACION", SqlDbType.DateTime);
        p_fechaCreacion.Value = guardar.FechaCreacion;
        SqlParameter p_titulo = commandSql.Parameters.Add("TITULO", SqlDbType.NChar);
        p_titulo.Value = guardar.Titulo;
        SqlParameter p_responsable = commandSql.Parameters.Add("RESPONSABLE", SqlDbType.NChar);
        p_responsable.Value = guardar.Responsable;
        SqlParameter p_usuario = commandSql.Parameters.Add("USUARIO", SqlDbType.NChar);
        p_usuario.Value = guardar.Usuario;
        SqlParameter p_habilitada = commandSql.Parameters.Add("HABILITADA", SqlDbType.Bit);
        p_habilitada.Value = guardar.Habilitada;
        SqlParameter p_descripcion = commandSql.Parameters.Add("DESCRIPCION", SqlDbType.NChar);
        p_descripcion.Value = guardar.Descripcion;
        Log.saveInLog("--------------Insert Task ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        foreach (SqlParameter item in commandSql.Parameters)
        {

            Log.saveInLog(item.ParameterName);
            Log.saveInLog(item.Value.ToString());
        }
        commandSql.Connection = sqlConn;
        try
        {
            sqlConn.Open();
            commandSql.ExecuteNonQuery();
            salida = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception guardarAtributo ABMCTask");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    /// <summary>
    /// Busca atributo para las consultas de filtros.
    /// </summary>
    public DataSet searchTask(String titulo, int tarea, String autor, String responsables)
    {


        String consultaBasica = "SELECT " +
                        "Id," +
                        "Identificador," +
                        "Autor," +
                        "FechaCreacion," +
                        "Titulo," +
                        "Responsable," +
                        "Usuario," +
                        "Habilitada" +
                        " FROM " +
                        " ProductoTareas ";

        bool buscarTitulo = false;
        bool buscarTarea = false;
        bool buscarResponsables = false;
        if (!string.IsNullOrEmpty(titulo)) buscarTitulo = true;
        if (!tarea.Equals(0)) buscarTarea = true;
        String consulta = consultaBasica + " WHERE ";
        System.Collections.ArrayList listaConsulta = new System.Collections.ArrayList();
        String datosConsulta = "";
        if (!autor.Equals("-") && !autor.Equals(" "))
        {
            datosConsulta= "Autor = @AUTOR";
            listaConsulta.Add(datosConsulta);
        };
        if (buscarTitulo)
        {
            datosConsulta = "Titulo LIKE @TITULO ";
            listaConsulta.Add(datosConsulta);
        }
        if (buscarTarea)
        {
            datosConsulta = "Identificador = @IDENTIFICADOR ";
            listaConsulta.Add(datosConsulta);
        }
        if (buscarResponsables)
        {
            datosConsulta = "Responsable = @RESPONSABLE ";
            listaConsulta.Add(datosConsulta);
        }
        int comienzo = 0;
        foreach (String item in listaConsulta)
        {
            if(comienzo != 0){
                consulta = consulta + " AND ";
            }
            consulta = consulta + item;
            comienzo++;
        }
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        if (!autor.Equals("-") && !autor.Equals(" "))
        {
            SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
            p_autor.Value = autor;
        }
       
        if (buscarTarea)
        {
            SqlParameter p_tarea = commandSql.Parameters.Add("TAREA", System.Data.SqlDbType.Int);
            p_tarea.Value = tarea;
        }

        if (buscarTitulo)
        {
            SqlParameter p_titulo = commandSql.Parameters.Add("TITULO", System.Data.SqlDbType.NChar);
            p_titulo.Value = titulo + "%";
        }

        if (buscarResponsables)
        {
            SqlParameter p_responsable = commandSql.Parameters.Add("RESPONSABLE", System.Data.SqlDbType.NChar);
            p_responsable.Value = responsables + "%";
        }
        
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.Connection = sqlConn;
        DataSet ds = new DataSet();
        Log.saveInLog("--------------Busqueda de Tareas ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        foreach (SqlParameter item in commandSql.Parameters)
        {

            Log.saveInLog(item.ParameterName);
            Log.saveInLog(item.Value.ToString());
        }
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            da.Fill(ds, "Tareas");
        }
        catch (Exception e)
        {
            Log.saveInLog("Exception buscarAtributos ABMCProduct");
            Log.saveInLog(e.Message);
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    /// <summary>
    /// Busca las versiones de un atributo 
    /// </summary>
    /// <param name="identificador"></param>
    /// <param name="nombre"></param>
    /// <param name="estado"></param>
    /// <param name="autor"></param>
    /// <param name="responsables"></param>
    /// <param name="version"></param>
    /// <param name="fechaInicioDesde"></param>
    /// <param name="FechaInicioHasta"></param>
    /// <param name="fechaVigenciaDesde"></param>
    /// <param name="fechaVigenciaHasta"></param>
    /// <param name="fechaCreacionDesde"></param>
    /// <param name="fechaCreacionHasta"></param>
    /// <returns></returns>
    public DataSet searchProductVersion(int identificador, int estado, String autor, int version, DateTime fechaInicioDesde, DateTime FechaInicioHasta, DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
    {


        String consultaBasica = " SELECT " +
            " Id," +
            "Identificador," +
            "Autor," +
            "Version," +
            "FechaCreacion," +
            "FechaVigenciaDesde," +
            "FechaVigenciaHasta," +
            "Nombre," +
            "Descripcion," +
            "Familia," +
            "Estado" +
            " FROM " +
            "ProductoInformacionGeneral";

        bool buscarVersion = false;
        bool buscarInicio = false;
        bool buscarCreacion = false;
        if (!version.Equals(0)) buscarVersion = true;
        if (fechaInicioDesde != DateTime.MinValue && FechaInicioHasta != DateTime.MinValue) buscarInicio = true;
        if (fechaCreacionDesde != DateTime.MinValue && fechaCreacionHasta != DateTime.MinValue) buscarCreacion = true;
        String consulta = consultaBasica + " WHERE Identificador = @IDENTIFICADOR";
        if (!autor.Equals("-") && !autor.Equals(" ") && !autor.Equals(""))
        {
            consulta = consulta + " AND Autor = @AUTOR";
        }
        if (estado >= 0)
        {
            consulta = consulta + " AND Estado = @ESTADO";
        }
        if (buscarVersion)
        {
            consulta += " AND Version = @VERSION";
        }
        if (buscarInicio)
        {
            consulta += " AND FechaVigenciaDesde BETWEEN @FechaInicioDesde AND @FechaInicioHasta";
        }
        if (buscarCreacion)
        {
            consulta += " AND FechaCreacion BETWEEN @FechaCreacionDesde AND @FechaCreacionHasta";
        }
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", System.Data.SqlDbType.Int);
        p_identificador.Value = identificador;

        if (!autor.Equals("-") && !autor.Equals(" ") && !autor.Equals(""))
        {
            SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
            p_autor.Value = autor;
        }

        if (buscarVersion)
        {
            SqlParameter p_version = commandSql.Parameters.Add("VERSION", System.Data.SqlDbType.NChar);
            p_version.Value = version;
        }

        if (buscarCreacion)
        {
            SqlParameter p_fechaCreacionDesde = commandSql.Parameters.Add("FechaCreacionDesde", System.Data.SqlDbType.DateTime);
            p_fechaCreacionDesde.Value = fechaCreacionDesde;

            SqlParameter p_fechaCreacionHasta = commandSql.Parameters.Add("FechaCreacionHasta", System.Data.SqlDbType.DateTime);
            p_fechaCreacionHasta.Value = fechaCreacionHasta;
        }
        if (buscarInicio)
        {
            SqlParameter p_fechaInicioDesde = commandSql.Parameters.Add("FechaInicioDesde", System.Data.SqlDbType.DateTime);
            p_fechaInicioDesde.Value = fechaInicioDesde;

            SqlParameter p_fechaInicioHasta = commandSql.Parameters.Add("FechaInicioHasta", System.Data.SqlDbType.DateTime);
            p_fechaInicioHasta.Value = FechaInicioHasta;
        }
        if (estado >= 0)
        {

            SqlParameter p_estado = commandSql.Parameters.Add("ESTADO", SqlDbType.NChar);
            switch (estado)
            {
                case 0:
                    p_estado.Value = Product.ENCURSO;
                    break;
                case 1:
                    p_estado.Value = Product.RECHAZADO;
                    break;
                case 2:
                    p_estado.Value = Product.ACEPTADO;
                    break;
                default:
                    break;
            }

        }
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Versionado Producto ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        foreach (SqlParameter item in commandSql.Parameters)
        {

            Log.saveInLog(item.ParameterName);
            Log.saveInLog(item.Value.ToString());
        }
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            da.Fill(ds, "Atributos");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception buscarAtributosVersionado ABMCProducto");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }


        return ds;
    }


    public Boolean deleteProduct(int pId)
    {
        String consulta = "DELETE FROM ProductoInformacionGeneral WHERE Id = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Producto ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        Log.saveInLog("El id es : " + pId.ToString()); 
        try
        {
            sqlConn.Open();
            commandSql.ExecuteNonQuery();
            salida = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception eliminar ABMCProducto");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }


}
