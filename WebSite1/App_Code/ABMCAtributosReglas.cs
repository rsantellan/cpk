using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Descripción breve de ABMCAtributosReglas
/// </summary>
public class ABMCAtributosReglas
{
	public ABMCAtributosReglas()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public void replicateDataRule(int pIdentificador, int version, int versionNueva)
    {
        String sql = "SELECT IDRegla,NomRegal, IDAttRelacionado, NomModoEjecucion, VersionAttRelacionado FROM AttrReglas WHERE IDAttRelacionado = @IDENTIFIER AND VersionAttRelacionado = @VERSION ORDER BY IDRegla ASC;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFIER", SqlDbType.Int);
        p_identificador.Value = pIdentificador;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = version;

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
            Log.saveInLog("Exception obtenerAtributo ABMCFamilia");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        
        if (ds.Tables.Count == 0) return;
        List<int> listaIdViejos = new List<int>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            listaIdViejos.Add(Convert.ToInt16(row[0].ToString()));
            this.insertAtributeRule(row[1].ToString(), Convert.ToInt16(row[2].ToString()), row[3].ToString(), versionNueva);
        }
        List<int> listaIdNuevos = this.getRulesId(pIdentificador, versionNueva);
    }

    private List<int> getRulesId(int pIdentifier, int pVersion)
    {
        String sql = "SELECT IDRegla,NomRegal, IDAttRelacionado, NomModoEjecucion, VersionAttRelacionado FROM AttrReglas WHERE IDAttRelacionado = @IDENTIFIER AND VersionAttRelacionado = @VERSION ORDER BY IDRegla ASC;";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFIER", SqlDbType.Int);
        p_identificador.Value = pIdentifier;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = pVersion;

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
            Log.saveInLog("Exception obtenerAtributo ABMCFamilia");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        List<int> salida = new List<int>();
        if (ds.Tables.Count == 0) return salida;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            salida.Add(Convert.ToInt16(row[0].ToString()));
            
        }
        return salida;
    }

    private void replicateDataCondition(List<int> listaVieja, List<int> listaNueva,int pIdentifier, int pVersion)
    {
        //List<int> listaId = this.getRulesId(pIdentifier, pVersion);
        String sql = "SELECT id,idRegla,AtributoID,AtributoNom,OpreradorAritmetico,ValorAttr,OperadorLogico FROM AttrReglasCondicion WHERE idRegla = @ID";
        List<int> idCondicionesViejos = new List<int>();
        for (int i = 0; i < listaVieja.Count; i++) // Loop through List with for
        {
            int idNuevo = listaNueva[i];
            int idViejo = listaVieja[i];
            SqlCommand commandSql = new SqlCommand();
            SqlConnection sqlConn = DBManager.getInstanceOfConnection();
            commandSql.CommandText = sql;
            commandSql.Connection = sqlConn;
            SqlParameter p_id = commandSql.Parameters.Add("ID", SqlDbType.Int);
            p_id.Value = idViejo;

            DataSet ds = new DataSet();
            try
            {
                sqlConn.Open();
                SqlDataAdapter da = new SqlDataAdapter(commandSql);
                sqlConn.Close();
                da.Fill(ds, "Condicion");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Log.saveInLog("Exception obtenerAtributo ABMCFamilia");
                Log.saveInLog(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }

            if (ds.Tables.Count == 0) return;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int idCondicionViejo = Convert.ToInt16(row[0].ToString());
                this.insertAtributeCondition(idNuevo, Convert.ToInt16(row[2].ToString()), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                
            }
        }

    }

    private void insertAtributeCondition(int pIdRegla, int pAtributoId, String pAttNombre,String pOperador, String pValor, String pOperadorLogico )
    {
        String sql = "INSERT INTO " +
                        "AttrReglasCondicion" +
                      "(" +
                        "idRegla," +
                        "AtributoID," +
                        "AtributoNom," +
                        "OpreradorAritmetico," +
                        "ValorAttr," +
                        "OperadorLogico"+
                      ") " +
                        "VALUES (" +
                        "@idRegla," +
                        "@AtributoID," +
                        "@AtributoNom," +
                        "@OpreradorAritmetico," +
                        "@ValorAttr," +
                        "@OperadorLogico" +
                     ");";

        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_idRegla = commandSql.Parameters.Add("idRegla", SqlDbType.Int);
        p_idRegla.Value = pIdRegla;
        SqlParameter p_idAtt = commandSql.Parameters.Add("AtributoID", SqlDbType.Int);
        p_idAtt.Value = pAtributoId;
        SqlParameter p_nombre = commandSql.Parameters.Add("AtributoNom", SqlDbType.NChar);
        p_nombre.Value = pAttNombre;
        SqlParameter p_operador = commandSql.Parameters.Add("OpreradorAritmetico", SqlDbType.NChar);
        p_operador.Value = pOperador;
        SqlParameter p_valor = commandSql.Parameters.Add("ValorAttr", SqlDbType.NChar);
        p_valor.Value = pValor;
        SqlParameter p_opLogico = commandSql.Parameters.Add("OperadorLogico", SqlDbType.NChar);
        p_opLogico.Value = pOperadorLogico;
        Log.saveInLog("--------------Insert Condicion ---------------");
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception guardarRegla ABMCAtributoRegla");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
    }

    private void insertAtributeRule(String pNomRegla, int pIdentificador, String pNomEjecucion, int pVersion)
    {
        String sql = "INSERT INTO "+
                      " AttrReglas "+
                      " ( " +
                      "NomRegal,"+
                      "IDAttRelacionado,"+
                      "NomModoEjecucion,"+
                      "VersionAttRelacionado"+
                      ")"+ 
                      "VALUES ("+
                      "@NomRegla,"+
                      "@IDENTIFICADOR,"+
                      "@EJECUCION,"+
                      "@VERSION"+
                      ");";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_identificador = commandSql.Parameters.Add("IDENTIFICADOR", SqlDbType.Int);
        p_identificador.Value = pIdentificador;
        SqlParameter p_nombre = commandSql.Parameters.Add("NomRegla", SqlDbType.NChar);
        p_nombre.Value = pNomRegla;
        SqlParameter p_version = commandSql.Parameters.Add("VERSION", SqlDbType.Int);
        p_version.Value = pVersion;
        SqlParameter p_ejecuccion = commandSql.Parameters.Add("EJECUCION", SqlDbType.NChar);
        p_ejecuccion.Value = pNomEjecucion;
        Log.saveInLog("--------------Insert Regla ---------------");
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception guardarRegla ABMCAtributoRegla");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
    }

#region borrar
    public Boolean borrarTodo(int pId)
    {
        Boolean salida = this.deleteActions(pId);
        if (salida)
        {
            salida = this.deleteCondiciones(pId);
            if (salida)
            {
                salida = this.deleteReglas(pId);
            }
        }
        return salida;

            
    }

    private Boolean deleteReglas(int pId)
    {
        String consulta = "DELETE from AttrReglas where IDAttRelacionado = @ID";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Acciones de atributos ---------------");
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
            Log.saveInLog("Exception eliminar ABMCAtributosReglas");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    private Boolean deleteCondiciones(int pId)
    {
        String consulta = "DELETE from AttrReglasCondicion WHERE idRegla IN ( select IDRegla from AttrReglas where IDAttRelacionado = @ID)";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Condiciones de atributos ---------------");
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
            Log.saveInLog("Exception eliminar ABMCAtributosReglas");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

    private Boolean deleteActions(int pId)
    {
        String consulta = "DELETE FROM AttrReglasAccion WHERE idCondicion IN (select id from AttrReglasCondicion WHERE idRegla IN ( select IDRegla from AttrReglas where IDAttRelacionado = @ID))";
        SqlCommand commandSql = new SqlCommand();
        commandSql.CommandText = consulta;

        SqlParameter p_id = commandSql.Parameters.Add("ID", System.Data.SqlDbType.Int);
        p_id.Value = pId;
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        Boolean salida = false;
        commandSql.Connection = sqlConn;
        Log.saveInLog("--------------Eliminar Acciones de atributos ---------------");
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
            Log.saveInLog("Exception eliminar ABMCAtributosReglas");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return salida;
    }

#endregion
}
