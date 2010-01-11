using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Descripción breve de ABMCFamilyReview
/// </summary>
public class ABMCFamilyReview
{
	public ABMCFamilyReview()
	{
	}

    public DataSet retrieveAllFamilyReviewByFamilyId(int pId)
    {
        String sql = "SELECT " +
            "id," +
            "Estado," +
            "Observacion," +
            "Autor," +
            "Creado" +
            " FROM " +
            "FamiliaRevision " +
            "WHERE"+
            " id = @ID ";
        DataSet ds = new DataSet();
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_id.Value = pId;
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            sqlConn.Close();
            da.Fill(ds, "FamilyReview");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener atributo por id ABMCFamilyReview");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    public DataSet retrieveAllFamilyReview()
    {
        String sql = "SELECT "+
            "id,"+
            "Estado,"+
            "Observacion,"+
            "Autor," +
            "Creado" +
            " FROM " +
            "FamiliaRevision ";
        DataSet ds = new DataSet();
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            sqlConn.Close();
            da.Fill(ds, "FamilyReview");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener todas las review de todas las familias");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }


    public Boolean saveReviewOfFamily(FamilyReview review)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "FamiliaRevision " +
            "(" +
                "id," +
                "Estado," +
                "Observacion," +
                "Autor," +
                "Creado" +
            ")" +
            "VALUES"+
            "(" +
                "@ID," +
                "@ESTADO," +
                "@OBSERVACION," +
                "@AUTOR," +
                "@FECHA" +
            ");";
        commandSql.CommandText = sql;
        SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_id.Value = review.FamilyId;
        SqlParameter p_estado = commandSql.Parameters.Add("ESTADO", SqlDbType.NChar);
        p_estado.Value = review.Resolution;
        SqlParameter p_observation = commandSql.Parameters.Add("OBSERVACION", SqlDbType.NChar);
        p_observation.Value = review.Observation;
        SqlParameter p_autor = commandSql.Parameters.Add("AUTOR", SqlDbType.NChar);
        p_autor.Value = review.Author;
        SqlParameter p_date = commandSql.Parameters.Add("FECHA", SqlDbType.DateTime);
        p_date.Value = review.CreatedAt;
        Log.saveInLog("--------------Insert Familia Review ---------------");
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
            Log.saveInLog("Exception guardar ABMCFamilyReview");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
    
}
