using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// Descripción breve de ABMCAtributoTree
/// </summary>
public class ABMCAtributoTree
{
	public ABMCAtributoTree()
	{
    }
    #region Guardado

    public void saveNodes(int pIdAttViejo, int pIdAttNuevo)
    {
        DataSet datosViejos = this.getAllNodesOfAtt(pIdAttViejo);
        if (datosViejos.Tables.Count == 0) return;
        List<MyTreeNode> listaVieja = new List<MyTreeNode>();
        foreach (DataRow row in datosViejos.Tables[0].Rows)
        {
            MyTreeNode tn = new MyTreeNode();
            tn.Id = Convert.ToInt16(row[0].ToString());
            tn.Nombre = row[1].ToString();
            tn.IdParent = Convert.ToInt16(row[2].ToString());
            tn.IdAtt = Convert.ToInt16(row[3].ToString());
            listaVieja.Add(tn);
            this.insertTreeNode(tn.IdParent, pIdAttNuevo, tn.Nombre);
        }
        DataSet datosNuevos = this.getAllNodesOfAtt(pIdAttNuevo);
        List<MyTreeNode> listaNueva = new List<MyTreeNode>();
        foreach (DataRow row in datosNuevos.Tables[0].Rows)
        {
            MyTreeNode tn = new MyTreeNode();
            tn.Id = Convert.ToInt16(row[0].ToString());
            tn.Nombre = row[1].ToString();
            tn.IdParent = Convert.ToInt16(row[2].ToString());
            tn.IdAtt = Convert.ToInt16(row[3].ToString());
            listaNueva.Add(tn);
        }
        for (int x = 0; x < listaVieja.Count; x++)
        {
            MyTreeNode oldNode = listaVieja[x];
            MyTreeNode newNode = listaNueva[x];
            if (oldNode.IdParent != 0)
            {
                int parentId = this.getParentListId(listaVieja,oldNode.IdParent);
                MyTreeNode parentNode = listaNueva[parentId];
                this.updateTreeNode(newNode.Id, parentNode.Id);
            }
            this.insertTreeNodeLeave(oldNode.Id, newNode.Id);
        }
    }

    private void insertTreeNodeLeave(int idOld, int idNew)
    {
        DataSet oldData = this.getTreeNodeLeave(idOld);
        if (oldData.Tables.Count == 0) return;
        foreach (DataRow row in oldData.Tables[0].Rows)
        {
            this.saveTreeNodeLeave(idNew, Convert.ToBoolean(row[1].ToString()), Convert.ToBoolean(row[2].ToString()), Convert.ToBoolean(row[3].ToString()), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), Convert.ToDecimal(row[10].ToString()), Convert.ToDecimal(row[11].ToString()));
        }
    }

    private void saveTreeNodeLeave(int idTree, Boolean require, Boolean readOnly, Boolean multiSelect,String subType, String origin, String values, String rute, String method, String type, Decimal largo, Decimal pDecimal)
    {
        String sql = "INSERT INTO " +
                        "TreeEstructuraItems" +
                        "(" +
                            "  IDTreeEstructuraItem," +
                            "EsRequerido," +
                            "SoloLectura," +
                            "MultiSeleccion," +
                            "SubTipo," +
                            "OrigenDeDatos," +
                            "Valores," +
                            "Ruta," +
                            "Metodo," +
                            "Tipo," +
                            "Largo," +
                            "Decimales" +
                        ") " +
                        "VALUES (" +
                            "@IDTreeEstructuraItem," +
                            "@EsRequerido," +
                            "@SoloLectura," +
                            "@MultiSeleccion," +
                            "@SubTipo," +
                            "@OrigenDeDatos," +
                            "@Valores," +
                            "@Ruta," +
                            "@Metodo," +
                            "@Tipo," +
                            "@Largo," +
                            "@Decimales" +
                        ");";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_idTree = commandSql.Parameters.Add("IDTreeEstructuraItem", SqlDbType.Int);
        p_idTree.Value = idTree;
        SqlParameter p_requiere = commandSql.Parameters.Add("EsRequerido", SqlDbType.Bit);
        p_requiere.Value = require;
        SqlParameter p_readonly = commandSql.Parameters.Add("SoloLectura", SqlDbType.Bit);
        p_readonly.Value = readOnly;
        SqlParameter p_multiSelect = commandSql.Parameters.Add("MultiSeleccion", SqlDbType.Bit);
        p_multiSelect.Value = multiSelect;
        SqlParameter p_subtype = commandSql.Parameters.Add("SubTipo", SqlDbType.NChar);
        p_subtype.Value = subType;
        SqlParameter p_origin = commandSql.Parameters.Add("OrigenDeDatos", SqlDbType.NChar);
        p_origin.Value = origin;
        SqlParameter p_values = commandSql.Parameters.Add("Valores", SqlDbType.NChar);
        p_values.Value = values;
        SqlParameter p_rute = commandSql.Parameters.Add("Ruta", SqlDbType.NChar);
        p_rute.Value = rute;
        SqlParameter p_method = commandSql.Parameters.Add("Metodo", SqlDbType.NChar);
        p_method.Value = method;
        SqlParameter p_type = commandSql.Parameters.Add("Tipo", SqlDbType.NChar);
        p_type.Value = type;
        SqlParameter p_largo = commandSql.Parameters.Add("Largo", SqlDbType.Decimal);
        p_largo.Value = largo;
        SqlParameter p_decimal = commandSql.Parameters.Add("Decimales", SqlDbType.Decimal);
        p_decimal.Value = pDecimal;
        Log.saveInLog("--------------Insert Leave del tree ---------------");
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
            Log.saveInLog("Exception guardarRegla ABMCLeave");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
    }

    private DataSet getTreeNodeLeave(int id)
    {
        String sql = "SELECT  " +
                "IDTreeEstructuraItem, " +
                "EsRequerido, " +
                "SoloLectura, " +
                "MultiSeleccion, " +
                "SubTipo, " +
                "OrigenDeDatos, " +
                "Valores, " +
                "Ruta, " +
                "Metodo, " +
                "Tipo, " +
                "Largo, " +
                "Decimales " +
                "FROM  " +
                "TreeEstructuraItems  " +
                "WHERE " +
                "IDTreeEstructuraItem = @ID;";
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
            da.Fill(ds, "Tree");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtenerAtributo ABMCAtributoTree");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    

    private int getParentListId(List<MyTreeNode> lista, int idParent)
    {
        int i = 0;
        Boolean found = false;
        while (i < lista.Count && !found)
        {
            MyTreeNode node = lista[i];
            if (node.IdParent == idParent)
            {
                found = true;
            }
            else
            {
                i++;
            }
        }
        return i;
    }

    private void updateTreeNode(int pId, int pIdParent)
    {
        String sql = "UPDATE " +
                        " TreeNodos " +
                        " SET " +
                            " IDParent = @IDParent " +
                        " WHERE " +
                            " IDTree = @IDTree; ";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_idParent = commandSql.Parameters.Add("IDParent", SqlDbType.Int);
        p_idParent.Value = pIdParent;
        SqlParameter p_id = commandSql.Parameters.Add("IDTree", SqlDbType.Int);
        p_id.Value = pId;
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

    private void insertTreeNode(int pIdParent, int pAtributoId, String pAttNombre)
    {
        String sql = "INSERT INTO " +
                        "TreeNodos" +
                        "(" +
                            "NomTree," +
                            "IDParent," +
                            "IDAttr" +
                        ") " +
                        "VALUES (" +
                            "@NomTree," +
                            "@IDParent," +
                            "@IDAttr" +
                        ");";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_idParent = commandSql.Parameters.Add("IDParent", SqlDbType.Int);
        p_idParent.Value = pIdParent;
        SqlParameter p_idAtt = commandSql.Parameters.Add("IDAttr", SqlDbType.Int);
        p_idAtt.Value = pAtributoId;
        SqlParameter p_nombre = commandSql.Parameters.Add("NomTree", SqlDbType.NChar);
        p_nombre.Value = pAttNombre;
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

    private DataSet getAllNodesOfAtt(int pIdAtt)
    {
        String sql = "SELECT IDTree, NomTree, IDParent, IDAttr FROM TreeNodos WHERE IDAttr = @ID ORDER BY IDTree ASC";
        SqlCommand commandSql = new SqlCommand();
        SqlConnection sqlConn = DBManager.getInstanceOfConnection();
        commandSql.CommandText = sql;
        commandSql.Connection = sqlConn;
        SqlParameter p_rule = commandSql.Parameters.Add("ID", SqlDbType.Int);
        p_rule.Value = pIdAtt;

        DataSet ds = new DataSet();
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandSql);
            sqlConn.Close();
            da.Fill(ds, "Tree");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Log.saveInLog("Exception obtenerAtributo ABMCAtributoTree");
            Log.saveInLog(e.Message);
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    #endregion

    #region Borrado

    private Boolean deleteTreeLeave(int pId)
    {
        String consulta = "DELETE FROM " +
                                "TreeEstructuraItems " +
                            "WHERE " +
                                "IDTreeEstructuraItem IN " +
                            "( " +
                                "SELECT  " +
                                    "IDTree " +
                                "FROM " +
                                    "TreeNodos " +
                                "WHERE " +
                                    "IDAttr = @ID); "; ;
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

    private Boolean deleteTree(int pId)
    {
        String consulta = "SELECT  " +
                             "IDTree " +
                           "FROM " +
                             "TreeNodos " +
                           "WHERE " +
                             "IDAttr = @ID; "; ;
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

    public Boolean deleteAll(int pId)
    {
        if (this.deleteTreeLeave(pId))
        {
            this.deleteTree(pId);
        }
        else
        {

            return false;
        }
        return true;
    }
    #endregion
}

public class MyTreeNode
{
    private int _id;
    private String _nombre;
    private int _parent;
    private int _idAtt;

    public int Id { get { return this._id; } set { this._id = value; } }
    public String Nombre { get { return this._nombre; } set { this._nombre = value; } }
    public int IdParent { get { return this._parent; } set { this._parent = value; } }
    public int IdAtt { get { return this._idAtt; } set { this._idAtt = value; } }
}
