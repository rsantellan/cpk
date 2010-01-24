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
public class ABMCProductValue
{
    public ABMCProductValue()
    {
    }

    #region Bloqueo

    public static Boolean blockProduct(int pId)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
                    "ProductoTarifaBloquedo" +
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
        String consulta = "DELETE FROM ProductoTarifaBloquedo WHERE idProducto = @ID";
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
            "ProductoTarifaBloquedo " +
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

    public static DataSet retrieveProductValueByProductId(int pId)
    {
        String sql = "SELECT " +
            "IdProducto," +
            "Resolucion," +
            "Observacion," +
            "Usuario," +
            "creado," +
            "AdultosFemenino," +
            "AdultosMasculino," +
            "MayoresFemino," +
            "MayoresMasculino," +
            "Bloquedo" +
            " FROM " +
            "ProductoTarifa " +
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

    public DataSet retrieveAllProductValue()
    {
        String sql = "SELECT " +
                    "IdProducto," +
                    "Resolucion," +
                    "Observacion," +
                    "Usuario," +
                    "creado," +
                    "AdultosFemenino," +
                    "AdultosMasculino," +
                    "MayoresFemino," +
                    "MayoresMasculino," +
                    "Bloquedo" +
                    " FROM " +
                    "ProductoTarifa ";
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
            da.Fill(ds, "ProductValue");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener todas las review de todas las productos");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }


    public static Boolean saveValueOfProduct(ProductValue value)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
		String sql = "INSERT INTO " +
	                "ProductoTarifa" +
                    "(" +
                        "  IdProducto," +
                        "Resolucion," +
                        "Observacion," +
                        "AdultosFemenino," +
                        "AdultosMasculino," +
                        "MayoresFemino," +
                        "MayoresMasculino," +
                        "Bloquedo," +
                        "Usuario," +
                        "creado" +
                    ") " +
                    "VALUES (" +
                        "@IdProducto," +
                        "@Resolucion," +
                        "@Observacion," +
                        "@AdultosFemenino," +
                        "@AdultosMasculino," +
                        "@MayoresFemino," +
                        "@MayoresMasculino," +
                        "@Bloquedo," +
                        "@Usuario," +
                        "@creado" +
                    ");";
        commandSql.CommandText = sql;
        SqlParameter p_id = commandSql.Parameters.Add("IdProducto", SqlDbType.Int);
        p_id.Value = value.ProductId;
        SqlParameter p_resolucion = commandSql.Parameters.Add("Resolucion", SqlDbType.NChar);
        p_resolucion.Value = value.Resolution;
        SqlParameter p_observation = commandSql.Parameters.Add("Observacion", SqlDbType.NChar);
        p_observation.Value = value.Observation;
        SqlParameter p_autor = commandSql.Parameters.Add("Usuario", SqlDbType.NChar);
        p_autor.Value = value.Author;
        SqlParameter p_date = commandSql.Parameters.Add("creado", SqlDbType.DateTime);
        p_date.Value = value.CreatedAt;
        SqlParameter p_adultosFemeninos = commandSql.Parameters.Add("AdultosFemenino", SqlDbType.Int);
        p_adultosFemeninos.Value = value.FemeninoAdulto;
        SqlParameter p_adultosM = commandSql.Parameters.Add("AdultosMasculino", SqlDbType.Int);
        p_adultosM.Value = value.MasculinoAdulto;
        SqlParameter p_mayoresFemenino = commandSql.Parameters.Add("MayoresFemino", SqlDbType.Int);
        p_mayoresFemenino.Value = value.FemeninoAdultoMayor;
        SqlParameter p_mayoresMasculino = commandSql.Parameters.Add("MayoresMasculino", SqlDbType.Int);
        p_mayoresMasculino.Value = value.MasculinoAdultoMayor;
        SqlParameter p_bloqueado = commandSql.Parameters.Add("Bloquedo", SqlDbType.Bit);
        p_bloqueado.Value = 0;
        Log.saveInLog("--------------Insert Product Value ---------------");
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

}
