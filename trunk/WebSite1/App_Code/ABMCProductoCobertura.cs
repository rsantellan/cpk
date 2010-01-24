using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Descripción breve de ABMCProductoCobertura
/// </summary>
public class ABMCProductoCobertura
{
	public ABMCProductoCobertura()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static List<int> getProductoCovertura(int id)
    {
        String sql = "SELECT " +
                        "IdProducto," +
                        "IdCobertura " +
                        " FROM " +
                        " ProductoCobertura " +
                        " WHERE " +
                        " IdProducto = @ID;";
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
        List<int> salida = new List<int>();
        //Task salida = new Task();
        if (ds.Tables.Count == 0) return salida;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            salida.Add(Convert.ToInt16(row[1].ToString()));
        }
        return salida;
    }

    public static Boolean save(ProductoCobertura save)
    {
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        String sql = "INSERT INTO " +
            "ProductoCobertura " +
            "(" +
                "IdProducto," +
                "IdCobertura" +
            ")" +
            "VALUES"+
            "(" +
                "@IDPRODUCTO," +
                "@IDCOBERTURA" +

            ");";
        commandSql.CommandText = sql;
        SqlParameter p_idProducto = commandSql.Parameters.Add("IDPRODUCTO", SqlDbType.Int);
        p_idProducto.Value = save.IdProducto;
        SqlParameter p_idCobertura = commandSql.Parameters.Add("IDCOBERTURA", SqlDbType.NChar);
        p_idCobertura.Value = save.IdCondicionado;
        Log.saveInLog("--------------Insert Producto Condicionado ---------------");
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
            Log.saveInLog("Exception guardarAtributo ABMCProducto Condicionado");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }


    public Boolean deleteProductCondition(ProductoCobertura deleted)
    {
        String consulta = "DELETE FROM ProductoCobertura WHERE IdProducto = @IDPRODUCTO AND IdCobertura = @IDCOBERTURA";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;
        SqlParameter p_idProducto = commandSql.Parameters.Add("IDPRODUCTO", SqlDbType.Int);
        p_idProducto.Value = deleted.IdProducto;
        SqlParameter p_idCobertura = commandSql.Parameters.Add("IDCOBERTURA", SqlDbType.NChar);
        p_idCobertura.Value = deleted.IdCondicionado;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Producto Cobertura---------------");
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
            Log.saveInLog("Exception eliminar ABMCProductoCobertura");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
}
