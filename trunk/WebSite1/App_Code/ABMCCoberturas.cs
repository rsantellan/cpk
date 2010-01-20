using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Descripción breve de ABMCCoberturas
/// </summary>
public class ABMCCoberturas
{
    public ABMCCoberturas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static DataSet getAllCoberturas()
    {

        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.Connection = sqlConn;
        commandSql = sqlConn.CreateCommand();

        commandSql.CommandText = "SELECT " +
                            "Id," +
                            "Cobertura " +
                            "FROM " +
                            "Coberturas ;";
        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            sqlConn.Close();
            da.Fill(ds, "Coberturas");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtener atributo por identificador y version ABMCCobertura");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }
}
