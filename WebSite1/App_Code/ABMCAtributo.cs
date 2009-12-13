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
        }
        finally
        {
            sqlConn.Close();
        }

        max = max + 1;
        return max;
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
        //if (guardar.EsModificable)
        //{
        //    p_modificable.Value = '1';
        //}
        //else
        //{
        //    p_modificable.Value = '0';
        //}
        
        
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
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
    public DataSet buscarAtributos(String nombre, Boolean estado, String autor, String responsables, int version, DateTime fechaInicioDesde, DateTime FechaInicioHasta, DateTime fechaVigenciaDesde, DateTime fechaVigenciaHasta, DateTime fechaCreacionDesde, DateTime fechaCreacionHasta)
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
        String consulta = consultaBasica + " WHERE Autor = @AUTOR";
        if (estado)
        {
            consulta = consulta + " AND FechaVigenciaHasta >= @HOY";
        }
        else
        {
            consulta = consulta + " AND FechaVigenciaHasta < @HOY";
        }
        if (buscarNombre)
        {
            //consulta += " AND Nombre LIKE '@Nombre%' ";
        }
        if (buscarVersion)
        {
            consulta += " AND Version = @VERSION ";
        }
        if (buscarInicio)
        {
            //consulta += " AND FechaVigenciaDesde BETWEEN @FechaInicioDesde AND @FechaInicioHasta";
        }
        if (buscarCreacion)
        {
            consulta += " AND FechaCreacion BETWEEN @FechaCreacionDesde AND @FechaCreacionHasta";
        }
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;
        
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
        p_autor.Value = autor;

        SqlParameter p_fechaAhora = commandSql.Parameters.Add("HOY", System.Data.SqlDbType.DateTime);
        p_fechaAhora.Value = DateTime.Now;

        if (buscarVersion)
        {
            SqlParameter p_version = commandSql.Parameters.Add("VERSION", System.Data.SqlDbType.NChar);
            p_version.Value = version;
        }

        if (buscarNombre)
        {
            SqlParameter p_nombre = commandSql.Parameters.Add("Nombre", System.Data.SqlDbType.NChar);
            p_nombre.Value = nombre;
        }

        if (buscarCreacion)
        {
            SqlParameter p_fechaCreacionDesde = commandSql.Parameters.Add("FechaCreacionDesde", System.Data.SqlDbType.DateTime);
            p_fechaCreacionDesde.Value = fechaCreacionDesde;

            SqlParameter p_fechaCreacionHasta = commandSql.Parameters.Add("FechaCreacionHasta", System.Data.SqlDbType.DateTime);
            p_fechaCreacionHasta.Value = fechaCreacionHasta;
        }
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
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
        }
        finally
        {
            sqlConn.Close();
        }
        
        
        return ds;
    }
}
