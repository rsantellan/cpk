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
        System.Data.SqlClient.SqlCommand commandSql = new System.Data.SqlClient.SqlCommand();
        commandSql.CommandText = consulta;
        
        System.Data.SqlClient.SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
        p_autor.Value = autor;

        System.Data.SqlClient.SqlParameter p_fechaAhora = commandSql.Parameters.Add("HOY", System.Data.SqlDbType.DateTime);
        p_fechaAhora.Value = DateTime.Now;

        if (buscarVersion)
        {
            System.Data.SqlClient.SqlParameter p_version = commandSql.Parameters.Add("VERSION", System.Data.SqlDbType.NChar);
            p_version.Value = version;
        }

        if (buscarNombre)
        {
            System.Data.SqlClient.SqlParameter p_nombre = commandSql.Parameters.Add("Nombre", System.Data.SqlDbType.NChar);
            p_nombre.Value = nombre;
        }

        if (buscarCreacion)
        {
            System.Data.SqlClient.SqlParameter p_fechaCreacionDesde = commandSql.Parameters.Add("FechaCreacionDesde", System.Data.SqlDbType.DateTime);
            p_fechaCreacionDesde.Value = fechaCreacionDesde;

            System.Data.SqlClient.SqlParameter p_fechaCreacionHasta = commandSql.Parameters.Add("FechaCreacionHasta", System.Data.SqlDbType.DateTime);
            p_fechaCreacionHasta.Value = fechaCreacionHasta;
        }
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(commandSql);
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


        //this.conectar();

        //   c.Connection = this.conn;

        //   SqlDataAdapter da = new SqlDataAdapter(c);

        //   this.desconectar();

        //   DataSet ds = new DataSet();

        //   da.Fill(ds, nombreTabla);

        //   return ds;

        //c.CommandText = "SELECT * FROM USUARIO, CREDENCIAL " +

        //                       "WHERE ID_CREDENCIAL = @LOGIN AND ID_CREDENCIAL = LOGIN";

        //       SqlParameter p_ci = c.Parameters.Add("@LOGIN", SqlDbType.NChar);

        //       p_ci.Value = u.Credencial.Login;
    }
}
