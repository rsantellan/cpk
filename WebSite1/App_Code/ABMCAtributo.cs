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
/// Descripción breve de ABMCAtributo
/// </summary>
public class ABMCAtributo
{
    private Atributo _atributo;
    public ABMCAtributo()
    {
        //this._atributo = atributo;
    }

    public static int getIdentifierOfAtributeById(int id)
    {
        int identifier = 0;
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        try
        {
            commandSql.Connection = sqlConn;
            commandSql = sqlConn.CreateCommand();

            commandSql.CommandText = "SELECT Identificador FROM AtributoInformacionGeneral WHERE id = @ID ";
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
            Log.saveInLog("Exception Obtener identificador ABMCAtributo");
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
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        try
        {
            commandSql.Connection = sqlConn;
            commandSql = sqlConn.CreateCommand();

            commandSql.CommandText = "SELECT Identificador FROM AtributoInformacionGeneral WHERE Identificador = (SELECT MAX(Identificador)  FROM AtributoInformacionGeneral) ";
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
            Log.saveInLog("Exception obtener ultimo identificador ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }

        max = max + 1;
        return max;
    }

    public Atributo obtenerAtributoPorIdentificadorYVersion(int pIdentificador, int pVersion)
    {
        String sql = "SELECT " +
                        "Id," +
                        "Identificador," +
                        "Autor," +
                        "Version," +
                        "FechaCreacion," +
                        "FechaVigenciaDesde," +
                        "FechaVigenciaHasta," +
                        "Nombre," +
                        "Descripcion," +
                        "EsModificable" +
                        " FROM " +
                        " AtributoInformacionGeneral " +
                        " WHERE " +
                        " Identificador = @IDENTIFICADOR "+
                        " AND Version = @VERSION ";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_id = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_id.Value = pIdentificador;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = pVersion;
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
            Log.saveInLog("Exception obtener atributo por identificador y version ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        Atributo salida = new Atributo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            salida.Id = Convert.ToInt16(row[0].ToString());
            salida.Identificador = Convert.ToInt16(row[1].ToString());
            salida.Autor = row[2].ToString();
            salida.Version = Convert.ToInt16(row[3].ToString());
            salida.FechaCreacion = DateTime.Parse(row[4].ToString());
            salida.FechaVigenciaDesde = DateTime.Parse(row[5].ToString());
            salida.FechaVigenciaHasta = DateTime.Parse(row[6].ToString());
            salida.Nombre = row[7].ToString();
            salida.Descripcion = row[8].ToString();
            if (row[9].ToString().Equals("1"))
            {
                salida.EsModificable = true;
            }
            else
            {
                salida.EsModificable = false;
            }
            return salida;
        }
        else
        {
            return null;
        }
        
    }

    public Atributo obtenerAtributo(int id)
    {
        String sql = "SELECT "+
                        "Id,"+
                        "Identificador,"+
                        "Autor,"+
                        "Version,"+
                        "FechaCreacion,"+
                        "FechaVigenciaDesde,"+
                        "FechaVigenciaHasta,"+
                        "Nombre,"+
                        "Descripcion,"+
                        "EsModificable"+
                        " FROM "+
                        " AtributoInformacionGeneral "+
                        " WHERE " +
                        " Id = @ID;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
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
            Log.saveInLog("Exception obtenerAtributo ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        Atributo salida = new Atributo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            salida.Id = id;
            salida.Identificador = Convert.ToInt16(row[1].ToString());
            salida.Autor = row[2].ToString();
            salida.Version = Convert.ToInt16(row[3].ToString());
            salida.FechaCreacion = DateTime.Parse(row[4].ToString());
            salida.FechaVigenciaDesde = DateTime.Parse(row[5].ToString());
            salida.FechaVigenciaHasta = DateTime.Parse(row[6].ToString());
            salida.Nombre = row[7].ToString();
            salida.Descripcion = row[8].ToString();
            if (row[9].ToString().Equals("1"))
            {
                salida.EsModificable = true;
            }
            else
            {
                salida.EsModificable = false;
            }
            return salida;
        }
        else
        {
            return null;
        }
        
    }

    public Boolean updateAtributo(Atributo guardar)
    {
        String sql = " UPDATE AtributoInformacionGeneral " +
                    " SET " +
                    " Identificador = @IDENTIFICADOR," +
                    " Autor = @AUTOR," +
                    " Version = @VERSION," +
                    " FechaCreacion = @FECHACREACION," +
                    " FechaVigenciaDesde = @FECHAVIGENCIADESDE," +
                    " FechaVigenciaHasta = @FECHAVIGENCIAHASTA," +
                    " Nombre = @NOMBRE," +
                    " Descripcion = @DESCRIPCION," +
                    " EsModificable = @ESMODIFICABLE " +
                    " WHERE " +
                    " Id = @ID;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        Boolean salida = false;
        commandSql.CommandText = sql;
        SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_id.Value = guardar.Id;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_identificador.Value = guardar.Identificador;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = guardar.Autor;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = guardar.Version;
        SqlParameter p_fechaCreacion = commandSql.Parameters.Add("FECHACREACION", SqlDbType.DateTime);
        p_fechaCreacion.Value = guardar.FechaCreacion;
        SqlParameter p_fechaVigenciaDesde = commandSql.Parameters.Add("FECHAVIGENCIADESDE", SqlDbType.DateTime);
        p_fechaVigenciaDesde.Value = guardar.FechaVigenciaDesde;
        SqlParameter p_fechaVigenciaHasta = commandSql.Parameters.Add("FECHAVIGENCIAHASTA", SqlDbType.DateTime);
        p_fechaVigenciaHasta.Value = guardar.FechaVigenciaHasta;
        SqlParameter p_nombre = commandSql.Parameters.Add("NOMBRE", SqlDbType.NChar);
        p_nombre.Value = guardar.Nombre;
        SqlParameter p_descripcion = commandSql.Parameters.Add("DESCRIPCION", SqlDbType.NChar);
        p_descripcion.Value = guardar.Nombre;
        SqlParameter p_modificable = commandSql.Parameters.Add("ESMODIFICABLE", SqlDbType.Bit);
        p_modificable.Value = guardar.EsModificable;
        Log.saveInLog("--------------Update Atributos ---------------");
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
            Log.saveInLog("Exception  updateAtributo ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    public Boolean guardarAtributo(Atributo guardar)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "AtributoInformacionGeneral " +
            "(" +
                "Identificador," +
                "Autor," +
                "Version," +
                "FechaCreacion," +
                "FechaVigenciaDesde," +
                "FechaVigenciaHasta," +
                "Nombre," +
                "Descripcion," +
                "EsModificable" +
            ")" +
            "VALUES"+
            "(" +
                "@IDENTIFICADOR," +
                "@AUTOR," +
                "@VERSION," +
                "@FECHACREACION," +
                "@FECHAVIGENCIADESDE," +
                "@FECHAVIGENCIAHASTA," +
                "@NOMBRE," +
                "@DESCRIPCION," +
                "@MODIFICABLE"+
            ");";
        commandSql.CommandText = sql;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_identificador.Value = guardar.Identificador;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = guardar.Autor;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = guardar.Version;
        SqlParameter p_fechaCreacion = commandSql.Parameters.Add("FECHACREACION", SqlDbType.DateTime);
        p_fechaCreacion.Value = guardar.FechaCreacion;
        SqlParameter p_fechaVigenciaDesde = commandSql.Parameters.Add("FECHAVIGENCIADESDE", SqlDbType.DateTime);
        p_fechaVigenciaDesde.Value = guardar.FechaVigenciaDesde;
        SqlParameter p_fechaVigenciaHasta = commandSql.Parameters.Add("FECHAVIGENCIAHASTA", SqlDbType.DateTime);
        p_fechaVigenciaHasta.Value = guardar.FechaVigenciaHasta;
        SqlParameter p_nombre = commandSql.Parameters.Add("NOMBRE", SqlDbType.NChar);
        p_nombre.Value = guardar.Nombre;
        SqlParameter p_descripcion = commandSql.Parameters.Add("DESCRIPCION", SqlDbType.NChar);
        p_descripcion.Value = guardar.Nombre;
        SqlParameter p_modificable = commandSql.Parameters.Add("MODIFICABLE", SqlDbType.Bit);
        p_modificable.Value = guardar.EsModificable;
        Log.saveInLog("--------------Insert Atributos ---------------");
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
            Log.saveInLog("Exception guardarAtributo ABMCAtributo");
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
    public DataSet buscarAtributos(String nombre, int estado, String autor, String responsables, int version, DateTime fechaInicioDesde, DateTime FechaInicioHasta, DateTime fechaVigenciaDesde, DateTime fechaVigenciaHasta, DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
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
            "EsModificable" +
            " FROM " +
            "AtributoInformacionGeneral";

        bool buscarNombre = false;
        bool buscarVersion = false;
        bool buscarInicio = false;
        bool buscarVigencia = false;
        bool buscarCreacion = false;
        if (!string.IsNullOrEmpty(nombre)) buscarNombre = true;
        if (!version.Equals(0)) buscarVersion = true;
        if (fechaInicioDesde != DateTime.MinValue && FechaInicioHasta != DateTime.MinValue) buscarInicio = true;
        if (fechaVigenciaDesde != DateTime.MinValue && fechaVigenciaHasta != DateTime.MinValue) buscarVigencia = true;
        if (fechaCreacionDesde != DateTime.MinValue && fechaCreacionHasta != DateTime.MinValue) buscarCreacion = true;
        String consulta = consultaBasica + " WHERE ";
        System.Collections.ArrayList listaConsulta = new System.Collections.ArrayList();
        String datosConsulta = "";
        if (!autor.Equals("-") && !autor.Equals(" "))
        {
            datosConsulta= "Autor = @AUTOR";
            listaConsulta.Add(datosConsulta);
        };
        switch (estado)
        {
            case 0:
                datosConsulta = "FechaVigenciaHasta < @HOY";
                listaConsulta.Add(datosConsulta);
                break;
            case 1:
                datosConsulta =  "FechaVigenciaHasta >= @HOY";
                listaConsulta.Add(datosConsulta);
                break;
            default:
                break;
        }
        if (buscarNombre)
        {
            datosConsulta = "Nombre LIKE @Nombre ";
            listaConsulta.Add(datosConsulta);
        }
        if (buscarVersion)
        {
            datosConsulta = "Version = @VERSION ";
            listaConsulta.Add(datosConsulta);
        }
        if (buscarInicio)
        {
            datosConsulta = "FechaVigenciaDesde BETWEEN @FechaInicioDesde AND @FechaInicioHasta";
            listaConsulta.Add(datosConsulta);
        }
        if (buscarVigencia)
        {
            datosConsulta = "FechaVigenciaHasta BETWEEN @FECHAVIGENCIADESDE AND @FECHAVIGENCIAHASTA";
            listaConsulta.Add(datosConsulta);
        }
        
        if (buscarCreacion)
        {
            datosConsulta = "FechaCreacion BETWEEN @FechaCreacionDesde AND @FechaCreacionHasta";
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
        if (comienzo != 0)
        {
            consulta = consulta + " AND ";
        }
        consulta += " Id IN (SELECT max(Id)"
                    + " FROM "
                    + "AtributoInformacionGeneral "
                    + "GROUP BY "
                    + "Identificador) AND FechaCreacion IS NOT NULL AND Autor <> ''";
        consulta += " ORDER BY Identificador";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        if (!autor.Equals("-") && !autor.Equals(" "))
        {
            SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
            p_autor.Value = autor;
        }
        switch (estado)
        {
            case -1:
                break;
            default:
                SqlParameter p_fechaAhora = commandSql.Parameters.Add("HOY", System.Data.SqlDbType.DateTime);
                p_fechaAhora.Value = DateTime.Now;
                break;
        }

        if (buscarVersion)
        {
            SqlParameter p_version = commandSql.Parameters.Add("VERSION", System.Data.SqlDbType.NChar);
            p_version.Value = version;
        }

        if (buscarNombre)
        {
            SqlParameter p_nombre = commandSql.Parameters.Add("Nombre", System.Data.SqlDbType.NChar);
             p_nombre.Value = nombre + "%";
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
        if (buscarVigencia)
        {
            SqlParameter p_fechaFinDesde = commandSql.Parameters.Add("FECHAVIGENCIADESDE", System.Data.SqlDbType.DateTime);
            p_fechaFinDesde.Value = fechaVigenciaDesde;

            SqlParameter p_fechaFinHasta = commandSql.Parameters.Add("FECHAVIGENCIAHASTA", System.Data.SqlDbType.DateTime);
            p_fechaFinHasta.Value = fechaVigenciaHasta;
        }
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        DataSet ds = new DataSet();
        Log.saveInLog("--------------Modificacion Atributos ---------------");
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
            da.Fill(ds, "Atributos");
        }
        catch (Exception e)
        {
            Log.saveInLog("Exception buscarAtributos ABMCAtributo");
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
    public DataSet buscarAtributosVersionado(int identificador, String nombre, int estado, String autor, String responsables, int version, DateTime fechaInicioDesde, DateTime FechaInicioHasta, DateTime fechaVigenciaDesde, DateTime fechaVigenciaHasta, DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
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
            "EsModificable" +
            " FROM " +
            "AtributoInformacionGeneral";

        bool buscarNombre = false;
        bool buscarVersion = false;
        bool buscarInicio = false;
        bool buscarVigencia = false;
        bool buscarCreacion = false;
        if (!string.IsNullOrEmpty(nombre)) buscarNombre = true;
        if (!version.Equals(0)) buscarVersion = true;
        if (fechaInicioDesde != DateTime.MinValue && FechaInicioHasta != DateTime.MinValue) buscarInicio = true;
        if (fechaVigenciaDesde != DateTime.MinValue && fechaVigenciaHasta != DateTime.MinValue) buscarVigencia = true;
        if (fechaCreacionDesde != DateTime.MinValue && fechaCreacionHasta != DateTime.MinValue) buscarCreacion = true;
        String consulta = consultaBasica + " WHERE Identificador = @IDENTIFICADOR";
        if (!autor.Equals("-") && !autor.Equals(" ") && !autor.Equals(""))
        {
            consulta = consulta + " AND Autor = @AUTOR";
        }
        switch (estado)
        {
            case 0:
                consulta = consulta + " AND FechaVigenciaHasta < @HOY";
                break;
            case 1:
                consulta = consulta + " AND FechaVigenciaHasta >= @HOY";
                break;
            default:
                break;
        }
        if (buscarNombre)
        {
            consulta += " AND Nombre LIKE @Nombre";
        }
        if (buscarVersion)
        {
            consulta += " AND Version = @VERSION";
        }
        if (buscarInicio)
        {
            consulta += " AND FechaVigenciaDesde BETWEEN @FechaInicioDesde AND @FechaInicioHasta";
        }
        if (buscarVigencia)
        {
            consulta += " AND FechaVigenciaHasta BETWEEN @FECHAVIGENCIADESDE AND @FECHAVIGENCIAHASTA";
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

        switch (estado)
        {
            case -1:
                break;
            default:
                SqlParameter p_fechaAhora = commandSql.Parameters.Add("HOY", System.Data.SqlDbType.DateTime);
                p_fechaAhora.Value = DateTime.Now;
                break;
        }

        

        if (buscarVersion)
        {
            SqlParameter p_version = commandSql.Parameters.Add("VERSION", System.Data.SqlDbType.NChar);
            p_version.Value = version;
        }

        if (buscarNombre)
        {
            SqlParameter p_nombre = commandSql.Parameters.Add("Nombre", System.Data.SqlDbType.NChar);
            p_nombre.Value = nombre + "%";
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
        if (buscarVigencia)
        {
            SqlParameter p_fechaVigenciaDesde = commandSql.Parameters.Add("FECHAVIGENCIADESDE", System.Data.SqlDbType.DateTime);
            p_fechaVigenciaDesde.Value = fechaVigenciaDesde;

            SqlParameter p_fechaVigenciaHasta = commandSql.Parameters.Add("FECHAVIGENCIAHASTA", System.Data.SqlDbType.DateTime);
            p_fechaVigenciaHasta.Value = fechaVigenciaHasta;
        }
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Versionado Atributos ---------------");
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
            Log.saveInLog("Exception buscarAtributosVersionado ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }


        return ds;
    }


    public Boolean deleteAtribute(int pId)
    {
        String consulta = "DELETE FROM AtributoInformacionGeneral WHERE Id = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Atributos ---------------");
        Log.saveInLog(DateTime.Now.ToShortTimeString());
        Log.saveInLog(commandSql.CommandText);
        try
        {
            sqlConn.Open();
            commandSql.ExecuteNonQuery();
            salida = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception eliminar ABMCAtributo");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
}
