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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Descripción breve de ABMCObservacion
/// </summary>
public class ABMCObservacion
{
    public ABMCObservacion()
    {
    }

    public Boolean eliminarObservacion(int pId)
    {
        String consulta = "DELETE FROM observaciones WHERE id = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;
        SqlParameter p_id = commandSql.Parameters.Add("@ID", SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        Boolean salida = false;
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

    public int obtenerObservacionId(Observacion pObs)
    {

        String consulta = " SELECT " +
            " id," +
            "tarea," +
            "observacion," +
            "autor," +
            "fecha," +
            "object_id, " +
            "object_class, " +
            "object_version " +
            " FROM " +
            "observaciones " +
            " WHERE " +
            " object_id = @ID " +
            " AND object_class = @OBJECTCLASS "+
            " AND tarea = @TAREA " +
            " AND observacion = @OBSERVACION " +
            " AND autor = @AUTOR " +
            " AND fecha = @FECHA " +
            " AND object_version = @OBJECTVERSION";


        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pObs.ObjectId;
        SqlParameter p_class = commandSql.Parameters.Add("OBJECTCLASS", System.Data.SqlDbType.NChar);
        p_class.Value = pObs.ObjectClass;
        SqlParameter p_tarea = commandSql.Parameters.Add("TAREA", System.Data.SqlDbType.NChar);
        p_tarea.Value = pObs.Tarea;
        SqlParameter p_obs = commandSql.Parameters.Add("OBSERVACION", System.Data.SqlDbType.NChar);
        p_obs.Value = pObs.MiObservacion;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", System.Data.SqlDbType.NChar);
        p_autor.Value = pObs.Autor;
        SqlParameter p_fecha = commandSql.Parameters.Add("FECHA", System.Data.SqlDbType.DateTime);
        p_fecha.Value = pObs.Fecha;
        SqlParameter p_objectVersion = commandSql.Parameters.Add("OBJECTVERSION", System.Data.SqlDbType.Int);
        p_objectVersion.Value = pObs.ObjectVersion;
        
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            da.Fill(ds, "Observacion");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        if (ds.Tables.Count == 0) return 0;
        int salida = 0;
        foreach (DataRow row in ds.Tables["Observacion"].Rows)
        {
            salida = (int)row[0];
        }
        return salida;
    }

    public List<Observacion> obtenerObservaciones(String pObjectClass, int pObjectId, int pObjectVersion)
    {

        String consulta = " SELECT " +
            " id," +
            "tarea," +
            "observacion," +
            "autor," +
            "fecha," +
            "object_id, " +
            "object_class, " +
            "object_version " +
            " FROM " +
            "observaciones " +
            " WHERE " +
            " object_id = @ID " +
            " AND object_class = @OBJECTCLASS " +
            " AND object_version = @OBJECTVERSION";


        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pObjectId;
        SqlParameter p_class = commandSql.Parameters.Add("OBJECTCLASS", System.Data.SqlDbType.NChar);
        p_class.Value = pObjectClass;
        SqlParameter p_objectVersion = commandSql.Parameters.Add("OBJECTVERSION", System.Data.SqlDbType.Int);
        p_objectVersion.Value = pObjectVersion;
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        commandSql.Connection = sqlConn;
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            da.Fill(ds, "Observacion");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        List<Observacion> lista = new List<Observacion>();
        if (ds.Tables.Count == 0) return lista;
        foreach (DataRow row in ds.Tables["Observacion"].Rows)
        {
            Observacion ob = new Observacion();
            ob.Id = (int)row[0];
            ob.Tarea = (string)row[1];
            ob.MiObservacion = (string)row[2];
            ob.Autor = (string)row[3];
            ob.Fecha = (DateTime)row[4];
            ob.ObjectId = (int)row[5];
            ob.ObjectClass = (string)row[6];
            ob.ObjectVersion = (int)row[7];
            lista.Add(ob);
        }
        return lista;
    }

    public Boolean guardarObservacion(Observacion pObs)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "observaciones " +
            "(" +
                "tarea," +
                "observacion," +
                "autor," +
                "fecha," +
                "object_id," +
                "object_class," +
                "object_version" +
            ")" +
            "VALUES" +
            "(" +
                "@TAREA," +
                "@OBSERVACION," +
                "@AUTOR," +
                "@FECHA," +
                "@OBJECTID," +
                "@OBJECTCLASS," +
                "@OBJECTVERSION" +
            ");";
        commandSql.CommandText = sql;
        SqlParameter p_tarea = commandSql.Parameters.Add("TAREA", SqlDbType.NChar);
        p_tarea.Value = pObs.Tarea;
        SqlParameter p_observacion = commandSql.Parameters.Add("OBSERVACION", SqlDbType.NChar);
        p_observacion.Value = pObs.MiObservacion;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = pObs.Autor;
        SqlParameter p_fecha = commandSql.Parameters.Add("FECHA", SqlDbType.DateTime);
        p_fecha.Value = pObs.Fecha;
        SqlParameter p_objectid = commandSql.Parameters.Add("OBJECTID", SqlDbType.Int);
        p_objectid.Value = pObs.ObjectId;
        SqlParameter p_objectclass = commandSql.Parameters.Add("OBJECTCLASS", SqlDbType.NChar);
        p_objectclass.Value = pObs.ObjectClass;
        SqlParameter p_objectVersion = commandSql.Parameters.Add("OBJECTVERSION", System.Data.SqlDbType.Int);
        p_objectVersion.Value = pObs.ObjectVersion;
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
}
