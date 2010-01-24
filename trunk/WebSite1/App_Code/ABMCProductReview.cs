using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Descripción breve de ABMCProductReview
/// </summary>
public class ABMCProductReview
{
    public ABMCProductReview()
	{
    }

    #region Bloqueo

    public static Boolean blockProduct(int pId)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
                    "ProductoRevisionBloquedo" +
                    "(" +
                        "IdProducto," +
                        "Bloqueado" +
                    ") " +
                    "VALUES (" +
                        "@IdProducto," +
                        "@Bloquedo" +
                    ");";
        commandSql.CommandText = sql;
        SqlParameter p_id = commandSql.Parameters.Add("IdProducto", SqlDbType.Int);
        p_id.Value = pId;
        SqlParameter p_bloqueado = commandSql.Parameters.Add("Bloquedo", SqlDbType.Bit);
        p_bloqueado.Value = 1;
        Log.saveInLog("--------------Block Product Value ---------------");
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
            Log.saveInLog("Exception guardar ABMCProductValue");
            Log.saveInLog(e.Message);
            salida = false;
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    public static Boolean deleteBlock(int pId)
    {
        String consulta = "DELETE FROM ProductoRevisionBloquedo WHERE idProducto = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Block ---------------");
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
            Log.saveInLog("Exception eliminar ABMCProductValue");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    public static DataSet retrieveBlockByProductId(int pId)
    {
        String sql = "SELECT " +
            "IdProducto," +
            "Bloquedo" +
            " FROM " +
            "ProductoRevisionBloquedo " +
            "WHERE" +
            " IdProducto = @ID ";
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
            da.Fill(ds, "ProducValue");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener atributo por id ABMCProductValue");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    #endregion

    public static DataSet retrieveProductReviewByProductId(int pId)
    {
        String sql = "SELECT " +
            "id," +
            "Estado," +
            "Observacion," +
            "Autor," +
            "Creado" +
            " FROM " +
            "ProductoRevision " +
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

    public DataSet retrieveAllProductReview()
    {
        String sql = "SELECT "+
            "id,"+
            "Estado,"+
            "Observacion,"+
            "Autor," +
            "Creado" +
            " FROM " +
            "ProductoRevision ";
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


    public static Boolean saveReviewOfProduct(ProductReview review)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "ProductoRevision " +
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
        p_id.Value = review.ProductId;
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
