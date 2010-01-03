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
/// Descripción breve de ABMCTreeNode
/// </summary>
public class ABMCTreeNode
{
	public ABMCTreeNode()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    private Boolean deleteTreeNodeData(int pIdAtt, int pIdVersion)
    {
        //Borro el contenido de los nodos.
        String consultaNodos = "DELETE FROM TreeEstructuraItems WHERE IDTreeEstructuraItem IN (" +
            "SELECT IDTree FROM TreeNodos WHERE IDAttr = @IDATT" +
            " AND IDVersion = @IDVERSION)";

        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consultaNodos;

        SqlParameter p_idAtt = commandSql.Parameters.Add("IDATT", System.Data.SqlDbType.Int);
        p_idAtt.Value = pIdAtt;
        SqlParameter p_idVersion = commandSql.Parameters.Add("IDVERSION", System.Data.SqlDbType.Int);
        p_idVersion.Value = pIdVersion;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Observacion ---------------");
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
            Log.saveInLog("Exception deleteTreeNodeData ABMCTreeNode");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
    public Boolean deleteTreeNodeStructure(int pIdAtt, int pIdVersion)
    {

        Boolean salida = this.deleteTreeNodeData(pIdAtt, pIdVersion);
        if (!salida) return salida;
        //Borro el contenido de los nodos.
        String consultaNodos = "DELETE FROM TreeNodos WHERE IDAttr = @IDATT"+
            " AND IDVersion = @IDVERSION";
  
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consultaNodos;

        SqlParameter p_idAtt = commandSql.Parameters.Add("IDATT", System.Data.SqlDbType.Int);
        p_idAtt.Value = pIdAtt;
        SqlParameter p_idVersion = commandSql.Parameters.Add("IDVERSION", System.Data.SqlDbType.Int);
        p_idVersion.Value = pIdVersion;

        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Observacion ---------------");
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
            Log.saveInLog("Exception  deleteTreeNodeStructure ABMCTreeNode");
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
