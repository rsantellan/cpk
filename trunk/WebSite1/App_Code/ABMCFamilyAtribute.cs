using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Descripción breve de ABMCFamilyAtribute
/// </summary>
public class ABMCFamilyAtribute
{
	public ABMCFamilyAtribute()
	{

	}

    /// <summary>
    /// Elimina todas las duplas que tiene el id de familia igual al pasado
    /// </summary>
    /// <param name="pId"></param>
    /// <returns></returns>
    public Boolean deleteWithFamilyId(int pId)
    {
        String consulta = "DELETE FROM FamiliaAtributo WHERE idFamilia = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar FamiliaAtributo por id Familia ---------------");
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
            Log.saveInLog("Exception eliminar ABMCFamilyAtribute");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }
}
